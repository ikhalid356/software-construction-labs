#Plot for Young buyers
mdata <- read.csv("mtcars.csv")
qsecs <- mdata$qsec
names(qsecs) <- mdata$model
barplot(qsecs, las=2, ylab="1/4 Mile time (Acceleration)", main="For young buyers")

#Plot for executive buyers
hp <- mdata$hp
names(hp) <- mdata$model
barplot(hp, las=2, ylab="Horsepower", main="For executive buyers")

data(AirPassengers)
AirPassengers[13]

apd <- matrix(AirPassengers, ncol=12, byrow=TRUE, dimnames = list( as.character(1949:1960), month.abb))
ticket_price = 500
apd <- apd * ticket_price
max(apd)
profit_month_val = max(apd)
profit_month = month.abb[which(apd == max(apd), arr.ind=TRUE)[2]]
print("Most profitable month: " )
print(profit_month)
print("Most profitable month value: " )
print(profit_month_val)

profit_year_val = max(rowSums(apd))
profit_year = as.character(1949:1960)[which(rowSums(apd) == max(rowSums(apd)), arr.ind=TRUE)]
print("Most profitable year: " )
print(profit_year)
print("Most profitable year value: " )
print(profit_year_val)

plot(AirPassengers*ticket_price, xlab="Year", ylab="Profit")
