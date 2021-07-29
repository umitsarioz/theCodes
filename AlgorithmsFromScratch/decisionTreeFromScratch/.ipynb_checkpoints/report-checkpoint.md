# 1. Decision Tree Algorithm

The decision trees algorithm is a series of questions that can take a yes or no answer in its
basic logic. The number of times "yes" or "no" answers are seen in calculation methods such
as Gini index and Information gain. Among the scores calculated according to the calculation
method, it is the one with the highest gain and the lowest value. Our aim is to find the
question values with the lowest score, that is, the highest gain.Our tree structure is divided
according to the value that brings the most profit. If certain conditions are met, the
classification is made and the tree is terminated, if not, the same operations (calculation,
finding the best value, etc.) continue until the conditions are met.
## 1.1. How to calculate scores? 
### 1.1.1. Gini Impurity

<center><img src="gini_formula.png" alt="gini_impurity_formula"></center>
<center> Figure 1.Gini Impurity Formula </center>

### 1.1.2. Information Gain 

<center><img src="entropy_formula.png" alt="entropy_impurity_formula"></center>
<center> Figure 2.Entropy Formula </center>

## 1.2. Decision Tree Classifier

<center><img src="dtclf.png" alt="decision_tree_classifier"></center>

The decision tree classifier construction I have set up in this document is shown in Figure 3.
Initially, three different conditions are checked, if these conditions are met, the classification
process is done and the tree is terminated, if not, other operations continue. These conditions
are as follows, if the number of data in the dataset, ie the tree structure, is less than the
min_sample I specified, terminate the tree and perform the classification process. If not less,
so if it's more than this value, there is still a possibility that operations can be performed on
the tree, so check the next conditions. In the next condition, if the current depth of my tree is
equal to the depth I determined at the beginning, end my tree and classify it because my tree
has reached the maximum depth. If this condition is not fulfilled, check the next condition. In the next condition check to see if the current tree structure is a leaf node as a node. If a leaf is
a node, it means that the node in our current tree has a single answer yes or no, so we have to
classify. If the leaf is not a leaf-node, we have to decide on the potential division values of
our current tree that we can divide. After deciding on the potential division values, we have to
calculate a score based on these values. I do this score calculation according to the method I
determined at the beginning, namely, impurity or information gain. I want both results to be
as low as possible so that I can get the highest gain on the current system. I divide the tree
construction for the values that yield the highest returns. I do this division by checking
whether my value providing the highest gain and the value in the data point I encounter is the
same or not. If it is the same, I am adding this set of values to the left sub-tree, otherwise I
add it to the right sub-tree. I repeat these processes until my initial three conditions are not
met.The decision tree classifier I set up enabled me to achieve a lower success rate as I expected.
I think the reason for this is that the classifier defined in scikit-learn gives the user much
more motion area while setting up the algorithm, unlike mine. For example, while both the
classifier I wrote and the classifier in scikit-learn have a maximum depth parameter, there is
no max_leaf nodes parameter when I write. That's why my tree continues instead of stopping
when it reaches a certain number of leaf knots. This causes the tree structure to be larger, i.e.
more complex, so I shift to overfit. I guess this decreases the success rate.
Another important observation is that although I have defined the decision tree classifiers in
scikit-learn with different calculation methods, I saw that I achieved the same success rates.
This made me think I might have made a mistake, and I wanted to check if the classifier gave
the same weights to the features when learning the dataset. When I checked this, I saw that
the tree structure formed by both classifiers was at the same depth, but the number of leaf
nodes was slightly different. I also found that different classifiers calculate different weights
for different properties, so my algorithm doesn't work incorrectly. So the algorithm works
correctly, but I think the reason I got similar success rates here is because the coefficients of
the features are too small to affect the success rate.
# References

[1] Wikipedia, “ Decision Tree Learning”, URL:
https://en.wikipedia.org/wiki/Decision_tree_learning#Gini_impurity (Access Date:
25.04.2021, 16:29) <br>
[2] Sebastian Mantey, “Coding a Decision Tree From Scratch in Python Video Series”, URL:
https://youtu.be/y6DmpG_PtN0 (Access Date: 24.04.2021) <br>
[3] Andreas C. Müller,Sarah Guido, Introduction to Machine Learning with Python.(2017)
<br>

> <b> More details about decision tree can find in the "project_file.ipynb" jupyter notebook file.