alter table LibroAutor
add Constraint FK_Libro_Autor_LibroId
FOREIGN KEY (LibroId)References Libro(LibroId)