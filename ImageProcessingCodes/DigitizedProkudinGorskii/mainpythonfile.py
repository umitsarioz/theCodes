#!usr/bin/env python3
# -*- coding: utf-8 -*-


import numpy as np  #using for array manipulation
import cv2  #using for reading image
from PIL import Image # using for reading and saving image 
import os,shutil #using for file operations
import matplotlib.pyplot as plt #using for showing images

"""# Load images"""

# path of images file.
#All images are here
dir = 'images'
#Lowest resolution images here
original_images_file = 'original_images'
#Colorized images are here
saving_path = 'colorized_images'
#Save path of lowest resolution images
lowResImages_path = []
#Save their names.
img_names = []

try:
  for filename in os.listdir(dir):
    if filename.endswith('.jpg'):
      im = (os.path.join(dir,filename)) #get file in the directory
      shape = cv2.imread(im).shape #Read an image and get shape of that.
      img_name = filename.split(sep='/')[-1].split(sep='.')[0] #first sep for take image full name, and sep again just for image name.
      #print(img_name,"shape is :",shape)
      if shape[0] <=1024 and shape[1]<=396: # choose lowest resolution images. check dimensions
        lowResImages_path.append(im)  # add full paths of the low resolution images.
        shutil.copy(im,original_images_file)
        img_names.append(img_name)
        #print(img_name,"shape is :",shape)
    else:
      continue
except:
  print("Exception occured while files are loading ! ")

def loadImg(img_path,img_name):
  '''
  This function load original image using full path by helping PIL lib.
  Input : 
  img_path : full path/directory of original image
  
  Output:
  return loaded image.
  '''
  try:
      img = Image.open(img_path)
      img = np.array(img).astype(np.uint8)
      print('Image: "',img_name,'" is loaded...')
      print("Shape of Image:",img.shape)
      return img
  except:
      print("Exception Occured, Image is not loaded ! ")

def divBGR(img):
    '''
    This function split our original image as Blue, Green , Red channels.
    Inputs:
    img : original image

    Outputs:
    return three images; b : blue channel
                        g : green channel
                        r : red channel
    '''

    w = img.shape[0] #width
    h = int(w/3) #height
    b = img[0:h,:] #new edges for blue 
    g = img[h:2*h,:] # new edges for green
    r = img[2*h:3*h,:] # new edges for red
    return b,g,r


  #Show just one image.
def showOne(img_first,img_final,img_name):
  '''
  This function shows images as unalignment and alignment .
  
  Inputs:
  img_first : not alignment image , so it's original one.
  img_final : alignment image and also combined.
  img_name : name of image file.
  
  Output:
  return: show images.
  '''
  fig,(ax1,ax2) = plt.subplots(1,2)
  fig.suptitle(img_name)
  ax1.imshow(img_first)
  ax2.imshow(img_final)

def ncc(img1, img2):
    '''
    This function is calculate mathematical formula is below  for apply align with ncc.

    Inputs:
    img1 : pixel values of img
    img2 : pixel values of img
    
    Output:
    return result mathematical formula np.sum(img1/norm_img1 * img2/norm_img2 )
    '''
    norm1 = img1 / np.linalg.norm(img1)
    norm2 = img2 / np.linalg.norm(img2)
    result = np.sum(norm1 * norm2)
    return result 

def align_ncc(img1,img2,p):
  '''
  This function find minimum axes to provide minimum distance.

  Inputs:
  img1 : pixel values of img1
  img2 : pixel values of img2
  p : start-stop points for exp. [-15,15]

  Output:
  return index values which providing minimum score.
  '''
  score_ncc = 0
  x_values=np.linspace(-p,p,2*p,dtype=np.uint8)
  y_values=np.linspace(-p,p,2*p,dtype=np.uint8)
  for x in x_values:
    for y in y_values:
       diff_ncc = ncc(img1 , np.roll(img2,[x,y],axis=(0,1)))
       if diff_ncc >= score_ncc:
          score_ncc = diff_ncc
          axes_ncc = [x,y]
  return axes_ncc


def ssd(img1,img2):
  #This function is simply apply Summation of Square Diffrence
  return np.sum(np.sum((img1-img2)**2))


def align_ssd(img1,img2,p):
  '''
  This function find minimum axes to provide minimum distance.

  Inputs:
  img1 : pixel values of img1
  img2 : pixel values of img2
  p : start-stop points for exp. [-15,15]

  Output:
  return index values which providing minimum score.
  '''
  score_ssd = 0
  x_values=np.linspace(-p,p,2*p,dtype=np.uint8)
  y_values=np.linspace(-p,p,2*p,dtype=np.uint8)
  for x in x_values:
    for y in y_values:
       diff_ssd = ssd(img1,np.roll(img2,[x,y],axis=(0,1)))
       if diff_ssd >= score_ssd:
          score_ssd = diff_ssd
          axes_ssd = [x,y]
  return axes_ssd

def renklendir(r,g,b):
  '''
  Inputs:
  r : alignment Red channel -- dtype: uint8
  g : alignment Green channel -- dtype: uint8
  b : original Blue channel --  dtype : uint8

  Output:
  return colorized image ; combine all and colorful.
  '''
  #crop rate
  p = 0.055

  #Combine images by helping numpy stack func.
  RtoG = np.dstack((r,g))
  RtoGtoB = np.dstack((RtoG,b))
  #final colorized image;Three channel is combined.
  colorized_img = RtoGtoB
  print("Combined all channels..")
  # For better solution;crop image vertically and horizontally.
  w1 = int(colorized_img.shape[0]*p)
  w2 = int(colorized_img.shape[0] - colorized_img.shape[0]*p)
  h1 = int(colorized_img.shape[1]* p)
  h2 = int(colorized_img.shape[1] - colorized_img.shape[1]*p)
  print("Croped image...")
  colorized_img = colorized_img[w1:w2,h1:h2]
  #convert array to image by helping PIL Image
  colorized_img = Image.fromarray(colorized_img)
  
  #I got error and couldnt handle this idk why so instead of that i used PIL
  '''
  print("running cv2 from array...")
  colorized_img = cv2.fromarray(np.array(colorized_img).astype(np.uint8))
  print("cv2 from array is over ... dtype: ",colized_img.dtype)
  print("cv2 convert color is running..")
  colorized_img = cv2.cvtColor(colorized_img,cv2.COLOR_RGB2BGR)
  print("cv2 convert is over... dtype: ",colorized_img.dtype)
  '''
  return colorized_img


def alignAndColorized(b,g,r):
  '''
  This function firstly align image each other.
  Secondly colorized image.

  Inputs:
  b : blue channel of original image
  g : green channel of original image
  r : red channel of original image

  Output:
  return colorized_img : it's mean 1-full img as rgb.
  '''
  # Find best score for alignment
  # Calculate alignment scores
  p = 15
  align_ncc_G2B = align_ncc(b,g,p)
  align_ncc_R2B = align_ncc(b,r,p)
  '''
  print('\n\tAlign NCC')
  print("Green to Blue : ",align_ncc_G2B)
  print('Red to Blue : ',align_ncc_R2B)
  '''
  align_ssd_G2B = align_ssd(b,g,p)
  align_ssd_R2B = align_ssd(b,r,p)
  '''
  print('\n\tAlign SSD')
  print('Green to Blue : ',align_ssd_G2B)
  print('Red to Blue : ',align_ssd_R2B)
  '''
  total_ncc = align_ncc_G2B[0] + align_ncc_G2B[1] + align_ncc_R2B[0] + align_ncc_R2B[1]
  total_ssd = align_ssd_G2B[0] + align_ssd_G2B[1] + align_ssd_R2B[0] + align_ssd_R2B[1]
  ncc_is_better = True
  if total_ssd > total_ncc:
    ncc_is_better = True
  else:
    ncc_is_better = False
  # Apply Alignment.
  if ncc_is_better:
    print("is using NCC for Alignment")
    try:
      green_ncc = np.roll(g, align_ncc_G2B, axis=(0,1))
      red_ncc = np.roll(r, align_ncc_R2B, axis=(0,1))
      print("ALIGNMENT SUCCEED")
    except:
      print("EXCEPTION OCCURED: ALIGNMENT ")
  
    try:
      img_colorized = renklendir(red_ncc,green_ncc,b)
      print("COLORIZED SUCCEED")
      return img_colorized
    except:
      print("EXCEPTION OCCURED : COLORIZED")

  else:
    print("is using SSD for Alignment")
    try:
      green_ssd = np.roll(g, align_ssd_G2B, axis=(0,1))
      red_ssd = np.roll(r, align_ssd_R2B, axis=(0,1))
      print("ALIGNMENT SUCCEED")
    except:
      print("EXCEPTION OCCURED: ALIGNMENT ")
   
    try:
      img_colorized = renklendir(red_ssd,green_ssd,b)
      print("ALIGNMENT SUCCEED")
      return img_colorized
    except:
      print("EXCEPTION OCCURED: COLORIZED")

def saveColorizedImg(img,img_name):
  '''
  This function simply save our colorized img.
  Inputs:
  img : our colorized img
  img_name : i used for saving like  img_name + 'blablabla'.
  Output:
  Show information about saving process.  
  '''

  img.save('{}/{}_renkli.jpg'.format(saving_path,img_name))
  print("Colorized image is saved your local disk as ",img_name,"_renkli.jpg \n")


def runAllOneTime(img_path,img_name):
  '''
  This function is run all functions. I used this function for to group all functions.
  Inputs:
  img : original image directory
  img_name : original image file name
  Output:
  Show informations about processes.
  '''
  try:
    img = loadImg(img_path,img_name)
  except:
    print("EXCEPTION OCCURED : LOAD IMAGE")
  
  try:
    b,g,r = divBGR(img)
    print("SPLIT CHANNELS SUCCEED")
  except:
    print("EXCEPTION OCCURED : SPLIT IMAGE TO CHANNELS")
  
  img_colorized = alignAndColorized(b,g,r)
  
  try:
    img_orig = cv2.imread(img_path)
    showOne(img_orig,img_colorized,img_name)
  except:
   print("EXCEPTION OCCURED: SHOW IMAGES")
  try:
    saveColorizedImg(img_colorized, img_name)
  except:
    print("EXCEPTION OCCURED : SAVING IMAGE\n")

#showImages(b,g,r)

print("Total Image Count: ",len(img_names))
for i in range(len(img_names)):
    print("Step ",i+1,":")
    runAllOneTime(lowResImages_path[i],img_names[i])
print("\nAll image plates are converted !!!")
print("Colorized images are plotting..")

'''
Evaluation of colorization:
Alignment method is important. Because points calculated according the algorithm.
What can i do to get better result ? 
i did crop images as vertical and horizontal. So that i deleted border which is around images.
and also i tried so many points [-5,5]..,[-10,10]..,[-15,15]...,[-20,20]. 
If these points can be more correctly, our output image will be better.
'''