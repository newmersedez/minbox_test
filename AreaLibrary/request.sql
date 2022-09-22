SELECT prod.name AS [Имя продукта], cat.name AS [Имя категории]
FROM Products prod
	LEFT JOIN ProductsCategory prodcat ON prod.id = prodcat.products_id
	JOIN Category cat ON cat.id = prodcat.category_id
ORDER BY prod.name
