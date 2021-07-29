# Versions of libraries
  <table>
  <tr>  
    <td> Python </td>
    <td> 3.5 </td>
    </tr>
    <tr>
      <td> NumPy</td>
      <td> 1.19.5 </td>
    </tr>
    <tr>
      <td> OpenCV </td>
      <td> 4.0.1 </td>
  </tr>
  </table>
  
# CannyEdgeDetector
Canny edge detector from scratch in python programming language.

## 1.What's Canny Edge Detector?

The Canny edge detector is an edge detection operator that uses a multi-stage algorithm
to detect a wide range of edges in images. It was developed by John F. Canny in 1986.
Among the edge detection methods developed so far, Canny edge detection algorithm is
one of the most strictly defined methods that provides good and reliable detection, and
is therefore among the most popular methods. [1] Canny Edge Detector has multiple
steps. In next section you will see how i applied these steps.

## 2.Canny Edge Detector Steps

First of all let’s look original image or input:
<p align="center">
 <img src="/images/Original_Image.png" alt="original_image">
</p>
Canny edge detector can be split 6 steps:

<ol>
<li>Grayscale Conversion</li>
Canny edge detector is only working on grayscale images. So we should convert
image to gray. For this step i used opencv library and its cvtColor function.
 <p align="center">
<img src="/images/code_gray.png" alt="code_gray">
 </p>
 
Output of gray image is as below:

<p align="center"><img src="/images/Gray_Image.png" alt="gray_image"></p>

<li>Smoothing image</li>
In canny edge detector is affect easily from noise. So we should remove noise from
images as possible as. I used Gaussian filter to smoothing image to remove noise. For
that i used Gaussian function in opencv library. 

<p align="center"><img src="/images/code_gaussian.png" alt="code_gaussian"></p>

This function take three argument, image which is convolve gaussian matris, kernel size
is size of gaussian matrix, sigma is parameter which is in mathematical formula. 3X3
and 5x5 kernel matrix give us better solution. When kernel size is bigger, smoothing rate are increase. According to reference [1] i choosed kernel size 5 . Output image
which is applied gaussian filter is as below:

<p align="center"><img src="/images/Image_applied Gaussian filter.png" alt="gaussian_filtered_image"></p>

<li>Finding intensity gradients</li>
To find intensity gradients, firstly we should apply some spatial filters like
sobel,prewitt etc. I used sobel filters. And for that i used Sobel function in open-cv
library. Ix define vertical lines. Iy define horizontal lines.

<p align="center"><img src="/images/code_Ix_Iy.png" alt="code_ix_iy"></p>

<p align="center"><img src="/images/sobel_kernels.png" alt="sobel_kernels"></p>

We should convolve our blurred image these Sobel kernels. After that we have Ix and Iy
matrix. Output of Ix is as below:

<p align="center"><img src="/images/Image_applied sobel axis-X.png" alt="sobelX"></p>

And output of Iy is as below:

<p align="center"><img src="/images/Image_applied sobel axis-Y.png" alt="sobelY"></p>

To calculate gradient magnitude we should calculate hypotenus of these values. I used
for that mathematical formula and numpy library. So that i have gradient magnitude. 

<p align="center"><img src="/images/code_gradient.png" alt="code_gradient"></p>

 Output of gradient magnitude is as below: 
 
<p align="center"><img src="/images/Gradient_Image.png" alt="gradient_image"></p>

 And also we should have direction of the gradient magnitude.I know that a point’s
tanjant, its slope. So i calculate arctanjant from Ix and Iy. I know that tanjant’s period s
pi, if there are negative values i can turn these values positive by add pi(180). 

<p align="center"><img src="/images/code_slope.png" alt="code_slope"></p>

I wonder what’s output of slope. Output of slope is as below:

<p align="center"><img src="/images/slope.png" alt="slope_image"></p>


After these calculations i applied normalization to my image. So that my pixel
values can be more regular. I tried and saw that normalized pixel values(image)
is seen well. For that i used numpy library.
<p align="center"><img src="/images/code_norm.png" alt="code_norm"></p>

<li>Non-maximum Supression</li>
Non-maximum suppression is an edge-thinning technique. When edge direction
are calculated we can follow these image traces in image. 

<p align="center"><img src="/images/nms_full.png" alt="nms"></p>


These traces create areas. The point according to is which area, i looked pixels of the
point as after and before. When slope or direction is changed, these after and before
points shift values are changed. Let’s look image 14. There are some colorful areas. 
    • Red area covers [0, 22.5) and (157.5, 180] . So if pixel is at red area , i looked
    for before pixel (x,y-1) and after pixel(x,y+1).
    • Blue area covers between [22.5, 67.5). So if pixel is at blue area, i looked for
    before pixel (x-1,y) and after pixel(x+1, y)
    • Yellow area covers between [112.5, 157.5). So if pixel is at yellow area, i looked
    for before pixel(x-1,y) and after pixel (x+1, y)
    • Green area covers [112.5, 157.5). So if pixel is at green area, i looked for before
    pixel(x+1, y-1) and after pixel(x-1, y+1)
    • If current pixel is greater than both of his neihbors then i kept it. In conclusion,
    Non-max suppression algorithm gets thinner edges.
In this step, i looped through each pixel and choosed slope of pixels. Then i compare
the slope the pixel value. According the slope angle i defined area and applied steps as
above.
Output of non-max suppression is as below:

<p align="center"><img src="/images/Image_applied_non_max_ suppression.png" alt="image_nonmax"></p>

<li>Double Threshold</li>

In this step, threshold method is that define all pixels weak and strong. For doing
that I defined high and low ratio for threshold. Then calculate high and low
threshold value.If pixel value is higher than threshold, it’s strong. But if pixel
value is higher than low threshold and also smaller than high threshold, it’s
Image 15. Output is Applied Non-Max Suppression 
important but weak pixel. If the pixel is smaller than low, it’s not important pixel
so i didn’t take it. Output of image is applied double threshold is as below:

<p align="center"><img src="/images/Image_applied_threshold.png" alt="image_threshold"></p>

<li>Hysteresis</li>
In this step, if our images are weak and they are not neighbor to strong values
then it can also be strong. For doing that, i looped through each pixel in the image, if
the value of the pixel is weak andthere are not any neighboring pixel with value 255, i
set the value of the pixel to 0. Output of image which hyteresis is as below:

<p align="center"><img src="/images/Final_image.png" alt="final_image"></p>

</ol>


<b>REFERENCES<b>
<ol>
<li> [URL] https://en.wikipedia.org/wiki/Canny_edge_detector  </li>
<li> [URL] https://towardsdatascience.com/canny-edge-detection-step-by-step-in-python-computer-vision-b49c3a2d8123  </li>
<li> [URL]  http://www.adeveloperdiary.com/data-science/computer-vision/implement-canny-edge-detector-using-python-from-scratch/ </li>
<li> [URL] https://github.com/Prashant-mahajan/Canny-Edge-Detector-from-scratch/blob/master/cannyEdgeDetector.py  </li>
<li> [URL] https://github.com/adeveloperdiary/blog/tree/master/Computer_Vision/Canny_Edge_Detection  </li>

<li> [URL] https://github.com/cynicphoenix/Canny-Edge-Detector  </li>
<li> [URL]  https://iitmcvg.github.io/summer_school/Session3/ </li>
<li> [URL] http://bigwww.epfl.ch/demo/ip/demos/edgeDetector/  </li>
<li> [URL]  https://github.com/StefanPitur/Edge-detection---Canny-detector/blob/master/canny.py </li>
</ol>
