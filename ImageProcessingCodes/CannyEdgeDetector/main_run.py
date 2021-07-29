
#!/usr/bin/env python3
# -*- coding: utf-8 -*-

import numpy as np
import cv2 
from google.colab.patches import cv2_imshow
import os

# Image path
dir = os.getcwd()
os.chdir(dir)
img_path ='chihuahua-dog-puppy-cute-39317_small.jpeg'

# In this cell initial step(load image) coded.

#Read image
'''
My references For reading image,showing image and conversion to grayscale:
First practical.pdf of Introductino to Image Processing class and open-cv online-doc.

'''
def show(img):
  '''
  I typed my codes in Google Colab env. In this environment cv2.imshow is not working. Instead of that cv2_imshow can work. So I typed my codes as below.
  '''
  try:
    cv2.imshow(img)
  except:
    print("This block can NOT work on Google Colab...Alternative block is running..")
  try:
    cv2_imshow(img)
  except:
    print("This block can just work on Google Colab.. alternative block is running..")


def LoadImage(img_path):
  '''
  Input : original image path.
  Output: return our original image

  Definition:
  This function read/load image. For that i used cv2 library and its imread function. Using style is imread(image_full_path)
  References:
  '''
  original_image = cv2.imread(img_path)
  return original_image

original_image = LoadImage(img_path)
#show(original_image)

# In this cell You'll see STEP-1 
# Let's convert image to grayscale
def convertGrayScale(img):
  '''
  Input : img : original image 
  Output : return gray scale image

  Definition:
  This function convert colorful/original image to gray image.
  References:
  '''
  gray_image = cv2.cvtColor(img,cv2.COLOR_RGB2GRAY)
  return gray_image

gray_image = convertGrayScale(original_image)
#show(gray_image)

# In this cell You'll see STEP-2
# Step-2
# Image,Kernel size, Sigma degerleri
# apply gaussian filter to blur

def ApplyGaussianFilter(img):
  '''
  Input : img - gray image
  Output: return blurred_image : it's image that is applied gaussian filter.

  Definition:
  This function apply gaussian filter to gray image. For that i used cv2 library. GaussianBlur(gray_image,(kernel_size),sigma_value) is using style.
  For ref [wikipedia] i choose kernel_size = 5x5  and sigma = 1.25. 
  References:
  
  '''
  sigma = 1.25 # i tried so many sigma values and between 1-2 is nice
  blurred_image = cv2.GaussianBlur(img,(5,5),sigma)
  return blurred_image

blurred_image = ApplyGaussianFilter(gray_image)
#show(blurred_image)

#In this cell You'll see STEP 3.1 : Sobel filters
def ApplySobelFilter(img,k):
  '''
  Input: img -> blurred image 
          k -> kernel size
  Output: return   Ix -> is applied X direction (sobel X),
                   Iy -> is applied Y direction (sobel Y).

  Definition : 
  This function applied sobel filters to blurred image. Used cv2 library and Sobel function. Using style (image,pixel_type,sobel kind,kernel_size) . Ix is sobel X(1,0) , Iy is sobel Y(0,1).
  References:
  '''
  Ix = cv2.Sobel(img,cv2.CV_64F,1,0,ksize=k) # blurred image * Sobel filter(x) 
  Iy = cv2.Sobel(img,cv2.CV_64F,0,1,ksize=k) # blurred image * Sobel filter(y)
  return Ix,Iy

Ix, Iy = ApplySobelFilter(blurred_image,5)
#show(Ix)
#show(Iy)

# In this cell You'll see STEP 3.2 : Gradient magnitude and slope
def GandTheta(Ix,Iy):
  '''
  Input: Ix: Image is applied sobel X.
         Iy: Image is applied sobel Y.
  Output: return Gradient as G , Angle as theta.

  Definiton:
  This function calculate gradient and gradient magnitude angle. For that , numpy library is enough. Numpy square root, radian to degree and arc tanjant .
  sqrt is Square root. I used that to calculate hypotenus(G).
  rad2deg is convertion of radian to degree. I used function because np.arctan2 is return a radian value.
  Tanjant has pi period. So if theta is negative, i add pi for being positive.  

  References:
  '''
  G = np.sqrt((Ix**2)+(Iy**2))

  theta = np.rad2deg(np.arctan2(Iy,Ix))
  theta[theta<0] +=180 #convert negative values to positive
  return G,theta

def norm(img):
  '''
  img : image
  return img : normalized image

  Definition:
  Function is normalization an image . End of this step, our output will be better.

  References:
  '''
  img = np.multiply(img,255.0 / img.max()) #normalization
  return img  

G,theta = GandTheta(Ix,Iy)
G = norm(G)
#show(G)
#show(theta)

# In this cell You'll see STEP 4
def non_max_suppression(g, theta):
  '''
  Input: g is gradient_magnitude
         teta is angle of gradient_magnitude

  output : return output image which is appilied nonmax suppression algorithm

  as non max suppression algorithm every 45 deg. we look after and before pixels as direction(gradient magnitude angle/direction ).
  '''
  m, n = g.shape #row,col
  output = np.zeros((m,n))

  #Shift values
  dx = [0,0,-1,1,-1,1,1,-1,0,0]
  dy = [-1,1,-1,1,0,0,-1,1,-1,1]

  # Angle values.
  angles = [0,22.5,67.5,112.5,157.5,180]

  for row in range(m-1):
    for col in range(n-1):
        direction = theta[row, col]
        for count in range(int(np.floor(len(dx)/2))):
          if (angles[count] <= direction < angles[count+1]):
            before = g[row + dx[2 * count], col + dy[2 * count]]
            after = g[row+dx[(2 * count) + 1], col + dy[(2 * count) + 1]]
            break
          if direction == 180:
            before = g[row,col-1]
            after = g[row,col+1]
            break

        if g[row, col] >= before and g[row, col] >= after:
            output[row, col] = g[row, col]
  output = norm(output)
  return output

nonMax = non_max_suppression(G,theta)
#show(nonMax)

# In this cell You'll see Step 5 : double threshold 
def threshold(image, low, high, weak):
    '''
    Input: Image which is applied non max suppression algorithm.
           low : define low value boundary
           high : define high value boundary
           weak : weak points pixel value
    output:
          return image as threshold values. Also strong pixel values as rows and columns.
    
    Definition:

    Let's find strong and weak values. And define them. After that combine as these definitions in a new image. New image is output image which is created real image.
    '''
    output = np.zeros(image.shape)
    strong = 255

    strong_row, strong_col = np.where(image >= high) # If values are high,get these pixels' row and col values
    weak_row, weak_col = np.where((image <= high) & (image > low)) # Weak value condition is piksel values between high and low . 

    output[strong_row, strong_col] = strong
    output[weak_row, weak_col] = weak

    return output,strong_row,strong_col

# In this cell calculate Threshold Boundaries and apply function.
weak = 50
strong = 255
def calculateThresholdBoundaries(image):
  low_ratio = 0.10
  high_ratio = 0.20
  difference = np.max(image) - np.min(image)
  low = np.min(image) + (low_ratio * difference)
  high = np.min(image) + (high_ratio * difference)
  return low,high

low,high  = calculateThresholdBoundaries(nonMax)
thresholded_image,strong_row,strong_col = threshold(nonMax,low,high,weak)
#show(thresholded_image)

# In this cell You'll see STEP-6: 
'''
First define neighbors of strong values.
Then i looped through each pixel in the image.
If the pixel is weak then, i examined if there is neighbor to strong. If it's then it's weak else it's also should be  strong
I repeat these steps for all directions , top to bot , bot to top , left to right and right to left. And finally sum all of them.
Because of these summation there will be bigger value than 255. Finally i define these values 255 again.

'''

neighbors=[[0,1],[0,-1],[-1,0],[1,0],[-1,-1],[1,-1],[-1,1],[1,1]]
def top2bot(image,neighbors,weak):
  m,n = image.shape
  for row in range(1,m-1):
    for col in range(1,n-1):
      if image[row,col] == weak:
        for i in range(len(neighbors)):
          isNeighbor = True # There is a relationship as neighbor between strong and weak values
          if image[row + neighbors[i][0], col + neighbors[i][1]] == 255:
            image[row,col] = 255
            isNeighbor = False # No neighbor
        if isNeighbor == False: 
          image[row,col] = 0 # Then it's also strong.
  return image

def bot2top(image,neighbors,weak):
  m,n = image.shape
  for row in range(m-1,0,-1):
    for col in range(n-1,0,-1):
      if image[row,col] == weak:
        for i in range(len(neighbors)):
          isNeighbor = True # There is a relationship as neighbor between strong and weak values
          if image[row + neighbors[i][0], col + neighbors[i][1]] == 255:
            image[row,col] = 255
            isNeighbor = False # No neighbor
        if isNeighbor == False: 
          image[row,col] = 0 # Then it's also strong.
  return image

def left2right(image,neighbors,weak):
  m,n = image.shape
  for row in range(m-1,0,-1):
    for col in range(0,n-1):
      if image[row,col] == weak:
        for i in range(len(neighbors)):
          isNeighbor = True # There is a relationship as neighbor between strong and weak values
          if image[row + neighbors[i][0], col + neighbors[i][1]] == 255:
            image[row,col] = 255
            isNeighbor = False # No neighbor
        if isNeighbor == False: 
          image[row,col] = 0 # Then it's also strong.
  return image

def right2left(image,neighbors,weak):
  m,n = image.shape
  for row in range(0,m-1):
    for col in range(n-1,0,-1):
      if image[row,col] == weak:
        for i in range(len(neighbors)):
          isNeighbor = True # There is a relationship as neighbor between strong and weak values
          if image[row + neighbors[i][0], col + neighbors[i][1]] == 255:
            image[row,col] = 255
            isNeighbor = False # No neighbor
        if isNeighbor == False: 
          image[row,col] = 0 # Then it's also strong.
  return image

def hyteresis(t,b,l,r):
  final_image = t+b+l+r
  final_image[final_image > 255] = 255
  return final_image

t = top2bot(thresholded_image,neighbors,weak)
b = bot2top(thresholded_image,neighbors,weak)
l = left2right(thresholded_image,neighbors,weak)
r = right2left(thresholded_image,neighbors,weak)
final_image = hyteresis(t,b,l,r)
#show(final_image)

# In this cell All steps(images) shown ordered .
descriptsions = {"Original_Image":original_image,
                 "Gray_Image":gray_image,
                 "Image_applied Gaussian filter":blurred_image,
                 "Image_applied sobel axis-X":Ix,
                 "Image_applied sobel axis-Y":Iy,
                 "Gradient_Image":G,
                 "Image_applied non-max suppression":nonMax,
                 "Image_applied threshold":thresholded_image,
                 "Final_image":final_image}

for title,image in descriptsions.items():
    print("\t\t "+title+"\n")
    show(image)
    try:
      print("Image is saved your local disk as",title+".png","\nPath:",dir+title+".png")
      cv2.imwrite(title+'.png',image)
    except:
      pass
    print("\n")