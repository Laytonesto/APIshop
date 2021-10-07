
--Get Productos
CREATE PROCEDURE get_productos
@estado INT
AS 
SELECT * FROM productos WHERE estado = @estado
GO

--Update Productos
CREATE PROCEDURE update_producto 
@id INT,
@nombre VARCHAR(100),
@precio FLOAT
AS 

DECLARE @nombre1 VARCHAR(100);
DECLARE @precio1 FLOAT;

SELECT @nombre1 = productos.nombre_producto, @precio1 = productos.precio_unidad FROM productos WHERE [id_producto]= @id;

INSERT INTO log_producto ([id_producto],[precio],[nombre], [fecha])
VALUES (@id,@precio1,@nombre1,(SELECT CAST( GETDATE() AS Date)) )

UPDATE productos SET  
       [nombre_producto] = @nombre,
       [precio_unidad] = @precio
       WHERE [id_producto]= @id
GO

--Restar Unidades Productos
CREATE PROCEDURE update_unidades_productos
@id INT,
@unidades_menos INT
AS 
DECLARE @unidades1 INT;

SELECT @unidades1 = productos.cantidad_unidades FROM productos WHERE [id_producto]= @id;

UPDATE productos SET  
       [cantidad_unidades] = @unidades1 - @unidades_menos
       WHERE [id_producto]= @id
GO

--insert nuevo producto

CREATE PROCEDURE insert_producto
@nombre VARCHAR(100), 
@cantidad INT,
@precio FLOAT
AS 
INSERT INTO productos([nombre_producto],[cantidad_unidades],[precio_unidad],[estado])
VALUES (@nombre, @cantidad,@precio,1) 
GO

--Delete Producto
CREATE PROCEDURE delete_producto 
@id INT,
@estado INT
AS 

UPDATE productos SET  
       [estado] = @estado
       WHERE [id_producto]= @id
GO

--Registro Usuario
CREATE PROCEDURE register_usuario
@nombre VARCHAR(100), 
@genero VARCHAR(10),
@correo VARCHAR(100),
@password VARCHAR(1000)
AS 
INSERT INTO usuarios ([rol],nombre,genero,correo,[password])
VALUES (1,@nombre, @genero,@correo,@password) 
GO

--Get Usuario
CREATE PROCEDURE get_usuario
@correo VARCHAR(100),
@password VARCHAR(1000)
AS 
SELECT * FROM usuarios WHERE correo = @correo AND [password] = @password

GO

--Comprar Producto
CREATE PROCEDURE insert_compra
@id_usuario INT, 
@precio_neto FLOAT
AS 
SET IDENTITY_INSERT compra ON
INSERT INTO compra([id_compra],[fecha],[precio_neto])
VALUES (@id_usuario,(SELECT CAST( GETDATE() AS Date)),@precio_neto) 

SELECT @@IDENTITY
SET IDENTITY_INSERT compra OFF
GO

--Lista Comprar Producto
CREATE PROCEDURE insert_lista_compra
@id_producto INT,
@id_compra INT,
@precio FLOAT,
@unidades INT
AS 
INSERT INTO lista_compras([id_producto],[id_compra],[precio_unidad],[cantidad_unidades])
VALUES (@id_producto,@id_compra,@precio,@unidades) 
GO

execute insert_compra 1,600
execute get_usuario 'ervin@mail.com','1234'

