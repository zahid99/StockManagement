select Item.ItemName,Category.CategoryName,Company.CompanyName from Item,Category,Company where Item.CategoryId=Category.CategoryId AND Item.CompanyId=Item.CompanyId AND  item.CompanyId='1' ;
select Item.ItemName from Item where Item.CompanyId='1' AND Item.CategoryId='1' ;



select Item.ItemName,Category.CategoryName,Item.CompanyId,Item.CategoryId,Item.AvailableQuantity ,Company.CompanyName
from Item INNER JOIN Category ON Item.CategoryId=Category.CategoryId
INNER JOIN Company ON Item.CompanyId=Company.CompanyId
 where Item.CompanyId='2' AND Item.CategoryId='3'