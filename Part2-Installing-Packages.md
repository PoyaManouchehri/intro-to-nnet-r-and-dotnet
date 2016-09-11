#2. Installing R Packages

One of the biggest selling points of R is access to the rich set of statistical and visualisation packages that have been written for it by the community and organizations. Moreover, R makes it extremely trivial to import and use these packages both from its console, and from a R script.

You can see a full list of community contributed packages (here)[https://cran.r-project.org/web/packages/]. This is the default source which R looks at for fetching packages. For the purposes of this workshop we will be using a package called (nnet)[https://cran.r-project.org/web/packages/nnet/nnet.pdf], a popular implementation of a feed-forward neural network.


##Installing Packages

RStudio allows you to install packages through the UI, but we will do it more quickly from the command line.

1. Open __RStudio__.
2. In the console window, enter the following command: 
```
installed.packages()
```

This will display a list of currently installed packages

3. Now enter:
```
install.packages("nnet")
```

This should begin the process of downloading and installing the nnet package and any dependencies. You can check that the package was installed by running `installed.packages()` again.


##Attaching Packages

In order to use a package, it needs to be _attached_ to the current R session. We will need to do this at the beginning of each R session (it can be added to our scripts)

1. Use the `library()` function to attach __nnet__ (note quotation marks are _not_ used):
```
library(nnet)
```

2. Now enter:
```
print(nnet)
```

You should get a brief signature of the `nnet()` function.


##End of Part 2

We have packages loaded! Fantastic! Let's move on to [Part 3 - Loading Data](Part3-Loading-Data.md)

 