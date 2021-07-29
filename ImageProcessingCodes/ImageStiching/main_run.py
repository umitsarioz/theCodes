#!/usr/bin/env python3

import os
import numpy as np
import cv2 as cv

current_dir = os.getcwd()
saving_path = current_dir+'/images/'


# Load images
def load(image):
    '''
    This function load given image as grayscale
    '''
    return cv.imread(image)

def show(window_name, image):
    '''
    This function show given image which has given window_name in a window.
    '''
    cv.imshow(window_name, image)
    cv.waitKey(0)
    cv.destroyAllWindows()

def save(filename, image):
    try:
        filename = saving_path + filename
        cv.imwrite(filename, image)
        print(f"{filename.split(sep='/')[-1]} is saved in {filename}.")
    except:
        print(f"{filename} NOT SAVE!")


left_image_path = current_dir + '/images/left.jpeg'  # left image path
right_image_path = current_dir + '/images/right.jpeg'  # right image path


left = load(left_image_path) # load left image
show('Left Image',left)  #show left image in a window

right = load(right_image_path) # load right image
show('Right Image',right) # show right image in a window

### First Question's answer is beginning.
# I used ORB method for detect keypoints and descriptors.
metod = cv.ORB_create(nfeatures=1111) # create orb object
#metod = cv.SIFT() # There is no SIFT in recent OpenCV. So i used ORB.

def findKeyPoints(metod,image):
    '''
    This function find the key points and descriptors with created/given ORB for image.
    '''
    keypoints,descriptors = metod.detectAndCompute(image,None)
    return keypoints,descriptors

def drawKeyPoints(keypoints,image):
    '''
    This function draw keypoints which calculated keypoints before.
    '''
    return cv.drawKeypoints(image,keypoints,None,(50,0,255))

def showKeyPoints(keypoints_l,keypoints_r):
    '''
    This function shows all keypoints for left and right images in line.
    '''
    keypoints_l_all = list()
    keypoints_r_all = list()
    for i in range(len(keypoints_l)):
        keypoints_l_all.append(keypoints_l[i].pt)
        keypoints_r_all.append(keypoints_r[i].pt)
    print("***Keypoints of LEFT IMAGE :\n\n ",keypoints_l_all)
    print("\n***Keypoints of RIGHT IMAGE : \n\n",keypoints_r_all)

def showDescriptors(descriptors_l,descriptors_r):
    '''
    This function shows all descriptors for left and right image in line.
    '''
    descriptors_l_all = list()
    descriptors_r_all = list()
    for i in range(len(descriptors_l)):
        descriptors_l_all.append(descriptors_l[i])
        descriptors_r_all.append(descriptors_r[i])
    print("\n***Descriptors of LEFT IMAGE : \n\n",descriptors_l_all)
    print("\n***Descriptors of RIGHT IMAGE : \n\n",descriptors_r_all)

keypoints_l,descriptors_l = findKeyPoints(metod,left) # find keypoints and descriptors for LEFT image
keypoints_r,descriptors_r = findKeyPoints(metod,right)#  find keypoints and descriptors for RIGHT image

drawing_left = drawKeyPoints(keypoints_l,left) # draw keypoints for LEFT image
drawing_right = drawKeyPoints(keypoints_r,right) # draw keypoints for RIGHT image


# Show keypoints and descriptors in line.
showKeyPoints(keypoints_l,keypoints_r)
showDescriptors(descriptors_l,descriptors_r)

# Save keypoints image
save("keypoints_left.jpeg",drawing_left)
save("keypoints_right.jpeg",drawing_right)

# Show Keypoints of the image in window
show('KeyPoints of LEFT IMAGE',drawing_left)
show('KeyPoints of RIGHT IMAGE',drawing_right)

### First Question's solution is over.

## 2nd Questions's solution is beginning.

bf = cv.BFMatcher_create(cv.NORM_HAMMING)  # I used NORM_HAMMING because of using ORB.

matches = bf.knnMatch(descriptors_l, descriptors_r, k=2)  # matches.


def findGoodMatches(matches):
    '''
    This function apply threshold for finding better matches in all matches.
    '''
    # Apply threshold ratio to choose best matches
    good_matches = []
    for m1, m2 in matches:
        if m1.distance < m2.distance * 0.7:
            #print(f"GOOD! :: m1 distance:{m1.distance}\t\t m2 distance:{m2.distance} \t\t Ratio:{m2.distance * 0.73}")
            good_matches.append([m1])

    return good_matches


def showGoodMatches(matches):
    '''
    This function shows all GOOD matches' DISTANCES in line.
    '''
    good_matches_distances = list()
    for match in matches:
        for dist in match:
            # print(dist.distance)
            good_matches_distances.append(dist.distance)
    print("DISTANCES OF GOOD MATCHES : ", good_matches_distances)


good_matches = findGoodMatches(matches)  # find good matches
showGoodMatches(good_matches) # show distances of good matches in line

FLAG = cv.DrawMatchesFlags_NOT_DRAW_SINGLE_POINTS # Flag parameter for drawing matches.

img_matching_all = cv.drawMatchesKnn(left,keypoints_l,right,keypoints_r,matches,None,flags=FLAG) # draw all matches
img_matching_best = cv.drawMatchesKnn(left,keypoints_l,right,keypoints_r,good_matches,None,flags=FLAG) # draw only good matches

show('IMAGE of ALL Matching Keypoints',img_matching_all)
show('IMAGE of GOOD Matching Keypoints',img_matching_best)
# Save matches image
save("matches_all.jpeg",img_matching_all)
save("matches_good.jpeg",img_matching_best)

# 2nd Question's solution is over.
# 3rd Question's solution is beginning.

def convertKeyPoints4H(keypoints_l,keypoints_r,good_matches):
    '''
    This function convert keypoints for estimating homography matrix.
    '''
    MIN_MATCH = 12
    CURR_MATCH = len(good_matches)
    if CURR_MATCH > MIN_MATCH:
        print("CURRENT MATCHES COUNTS : ",CURR_MATCH)
        matchingPoints_l = list()
        matchingPoints_r = list()
        for match in good_matches:
            for m in match:
                matchingPoints_l.append(keypoints_l[m.queryIdx].pt)
                matchingPoints_r.append(keypoints_r[m.trainIdx].pt)
        # preparation for findHomography function.
        matchingPoints_l = np.float32(matchingPoints_l).reshape(-1,1,2)
        matchingPoints_r = np.float32(matchingPoints_r).reshape(-1,1,2)
        return matchingPoints_l, matchingPoints_r
    else:
        raise Exception("Current Match count is too low!")

def findHomographyMatrix(source_keypoints,destinition_keypoints,threshold):
    '''
    Find homography matrix for source -> destinion. My source is left image and destination is right image.
    '''
    keypoints_l = source_keypoints
    keypoints_r = destinition_keypoints
    homographyMatrix,_ = cv.findHomography(keypoints_l,keypoints_r,cv.RANSAC,threshold) #Apply RANSAC for finding Homography matrix.
    print("HOMOGRAPHY MATRIX : \n",homographyMatrix)
    return homographyMatrix

threshold=5.0
source,destinition = convertKeyPoints4H(keypoints_l,keypoints_r,good_matches)
homographyMatrix = findHomographyMatrix(source,destinition,threshold) # calculate matrix.

# 3rd Question's solution is over.
# 4th-5th Question's solutions.

def warpImages(left_img, right_img, homographyMatrix):
    HM = homographyMatrix
    wl, hl = left_img.shape[:2]  # Weight of Left image, Height of Left image
    wr, hr = right_img.shape[:2]  # Weight of Right image, Height of Right image

    reference_points = np.float32([[0, 0], [0, wl], [hl, wl], [hl, 0]]).reshape(-1, 1, 2)
    temp_points = np.float32([[0, 0], [0, wr], [hr, wr], [hr, 0]]).reshape(-1, 1,
                                                                           2)  # right image , which will be transformed.

    changedPerspective = cv.perspectiveTransform(temp_points, HM)  # Transformation matrix calculated.

    final_points = np.concatenate((reference_points, changedPerspective), axis=0)

    [x_min, y_min] = np.int32(final_points.min(axis=0).ravel())
    [x_max, y_max] = np.int32(final_points.max(axis=0).ravel())

    t_dist = [-x_min, -y_min]  # translation distances
    wFinal, hFinal = t_dist[0], t_dist[1]
    x, y = (x_max - x_min), (y_max - y_min)
    tm = np.array([[1, 0, t_dist[0]], [0, 1, t_dist[1]], [0, 0, 1]])  # translation_matrix
    '''
    3x3 Translation Matrix:
    | 1 0 Translation Distance For X | 
    | 0 1 Translation Distance For Y |
    | 0 0            1               |
    '''
    # Stitch image

    output_img = cv.warpPerspective(left_img, tm.dot(HM), (x, y))
    output_img[hFinal:hFinal + wl, wFinal:wFinal + hl] = right_img
    print("Referenec Points\n", reference_points)
    print("\nFinal Points\n", final_points)
    print("\nTranslation Matrix\n", tm)
    print("\nOutput Image\n", output_img)
    return output_img

img_stitched = warpImages(left,right,homographyMatrix)
show("Stiched Image",img_stitched)

save("lastimage.jpeg",img_stitched)