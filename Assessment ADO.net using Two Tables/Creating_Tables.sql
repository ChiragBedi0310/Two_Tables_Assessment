create table Category(
CategoryId int primary key,
CategoryName nvarchar(40)
)

create table Product(
ProductId int primary key,
ProductName nvarchar(40),
Price int,
CategoryId int foreign key references Category(CategoryId)
)