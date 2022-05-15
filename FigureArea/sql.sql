SELECT Products.ProductName, Categories.CategoryName
FROM Products
LEFT JOIN ProductCategories ON Products.Id = ProductCategories.ProductId
LEFT JOIN Categories ON ProductCategories.CategoryId = Categories.Id;