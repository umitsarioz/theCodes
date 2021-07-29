# Versions of libraries was used 
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
      <td> Scikit-Learn </td>
      <td> 0.24.1 </td>
     </tr>
  </table>

# kNearestNeighbors

  
<p align="center"><img src="knn.png" alt="knn"><br>Example Image for KNN</p>

## Information

The K-nearest neighbors algorithm is arguably one of the simplest machine learning algorithms. The working logic of the algorithm is as follows; A result is obtained by grouping the closest neighbors around a certain point according to a certain rules. The number of nearest neighbors is represented by k. Different measurement methods such as L1, L2 are used to determine the closest neighbors. The methods used in grouping these neighbors can be methods such as the most according to the most or the highest score. For example, let's say we have 10 red and blue points, 5 of them red and 5 blue. A new unknown point joins between these points. Let's use the k-nn algorithm to guess whether this point is red or blue.

Bu noktanın en yakın 3 komşuna bakmak için şu adımlar sırayla uygulanır:

## Steps
<ul>
<li>  The number of nearest neighbors to be looked after is determined. (For example, 3.)    </li>
<li>  The function of the method that will determine the distance between points is written / determined.  </li>
<li>  Distances are calculated   </li>
<li>  These points are ordered according to their distance, as far as possible.   </li>
<li>  How many neighbors have been determined, as many are selected.  </li>
<li>  Grouping is made according to the properties of the selected points. (For example: 2 of 3 points are blue and 1 is red. The majority is chosen as a method, in this case our new point will be blue.)</li>
</ul> 

# What are advantages and disadvantages?

Advantages:
<ul>
   <li>  Quick and simple to set up.</li>
    <li> Understandable</li>
    <li> It gives a certain good success rate, it can be preferred before moving to more advanced methods.</li>
</ul>
Disadvantages:
<ul>
   <li>  It works slowly on large datasets or when there are many feature counts.</li>
   <li>  Therefore, it is practically useless.</li>
   <li>  For the algorithm to work well, the data must be preprocessed.     </li>
</ul>    
   
    
## REFERENCES

<ol>
<li> Andreas C. Müller,Sarah Guido, Introduction to Machine Learning with Python.(2017) </li>
<li> Szeliski Richard, (2010). Computer Vision: Algorithms and Applications (pp. 384-387) </li>
</ol>
