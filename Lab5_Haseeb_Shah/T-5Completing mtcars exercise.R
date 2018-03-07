#Plot for Young buyers
mdata <- read.csv("mtcars.csv")
qsecs <- mdata$qsec
names(qsecs) <- mdata$model
barplot(qsecs, las=2, ylab="1/4 Mile time (Acceleration)", main="For young buyers")

#Plot for executive buyers
hp <- mdata$hp
names(hp) <- mdata$model
barplot(hp, las=2, ylab="Horsepower", main="For executive buyers")