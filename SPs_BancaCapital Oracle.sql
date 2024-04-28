/* PROCEDIMIENTOS ALMACENADOS PL/SQL */

/* PROCEDIMEITNOS ALMACENADOS DE TB_TIPO_CLIENTE */
CREATE OR REPLACE PROCEDURE USP_ListadoTipoClientes(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
            ID_TP_PERSONA,
            FECHA_CREACION,
            HORA_CREACION,
            TIPO_PERSONA
        FROM TB_TIPO_CLIENTE 
        WHERE ESTADO = 1 AND TIPO_PERSONA LIKE '%' || cTexto || '%'
        ORDER BY ID_TP_PERSONA DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.ID_TP_PERSONA || ', ' || rec.FECHA_REGISTRO || ', ' || rec.TIPO_PERSONA);
    END LOOP;
END USP_ListadoTipoClientes;
/

-- EXEC USP_ListadoTipoPersonas
CREATE OR REPLACE PROCEDURE USP_ListadoTipoClientesCaidos(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
            ID_TP_PERSONA,
            FECHA_REGISTRO,
            TIPO_PERSONA
        FROM TIPO_CLIENTE
        WHERE ESTADO = 0 AND TIPO_PERSONA LIKE '%' || cTexto || '%'
        ORDER BY ID_TP_PERSONA DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.ID_TP_PERSONA || ', ' || rec.FECHA_REGISTRO || ', ' || rec.TIPO_PERSONA);
    END LOOP;
END USP_ListadoTipoClientesCaidos;
/

-- EXEC USP_ListadoTipoPersonasCaidas
create or replace NONEDITIONABLE PROCEDURE USP_GuardarTipoCliente(
    nOpcion             IN INT DEFAULT 0,
    nId_Tp_Persona      IN INT DEFAULT 0,
    cTipo_Persona       IN VARCHAR2 DEFAULT '',
    cFecha_Modificacion IN DATE DEFAULT SYSDATE,
    cModificado_Por     IN VARCHAR2
)
AS
    xCodigo INT := 0;
    fFecha  DATE;
    empleado varchar2(50) := NULL;
BEGIN
    fFecha := SYSDATE;
    SELECT 'X' INTO empleado FROM tb_usuario
    where usuario = cModificado_Por;

IF empleado is not null then
    IF nOpcion = 1 THEN -- Nuevo Registro
        INSERT INTO tb_TIPO_CLIENTE (TIPO_PERSONA,ESTADO)
        VALUES (cTipo_Persona,1);
        --dbms_output.put_line('salida insert');
    ELSE -- Actualizar registro
        UPDATE tb_TIPO_CLIENTE
        SET
            TIPO_PERSONA = cTipo_Persona,
            FECHA_MODIFICACION = cFecha_Modificacion,
            MODIFICADO_POR = cModificado_Por
        WHERE 
            ID_TP_PERSONA = nId_Tp_Persona;
        --dbms_output.put_line('salida update');
    END IF;
end if;
commit;
END USP_GuardarTipoCliente;

CREATE OR REPLACE PROCEDURE USP_EliminarTipoCliente(
    nID_TP_PERSONA IN INT DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TIPO_CLIENTE
    SET ESTADO = 0
    WHERE ID_TP_PERSONA = nID_TP_PERSONA;
END USP_EliminarTipoCliente;
/

CREATE OR REPLACE PROCEDURE USP_LevantarTipoCliente(
    nID_TP_PERSONA IN INT DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TIPO_CLIENTE
    SET ESTADO = 1
    WHERE ID_TP_PERSONA = nID_TP_PERSONA;
END USP_LevantarTipoCliente;
/

/* PROCEDIMEITNOS ALMACENADOS DE TB_PAISES */
CREATE OR REPLACE PROCEDURE USP_ListadoPaises(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
            ID_PAIS,
            FECHA_REGISTRO,
            TIPO_PERSONA
        FROM TB_TIPO_CLIENTE 
        WHERE ESTADO = 1 AND TIPO_PERSONA LIKE '%' || cTexto || '%'
        ORDER BY ID_TP_PERSONA DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.ID_TP_PERSONA || ', ' || rec.FECHA_REGISTRO || ', ' || rec.TIPO_PERSONA);
    END LOOP;
END USP_ListadoPaises;
/

-- EXEC USP_ListadoTipoPersonas
CREATE OR REPLACE PROCEDURE USP_ListadoPaisesCaidos(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
            ID_TP_PERSONA,
            FECHA_REGISTRO,
            TIPO_PERSONA
        FROM TIPO_CLIENTE
        WHERE ESTADO = 0 AND TIPO_PERSONA LIKE '%' || cTexto || '%'
        ORDER BY ID_TP_PERSONA DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.ID_TP_PERSONA || ', ' || rec.FECHA_REGISTRO || ', ' || rec.TIPO_PERSONA);
    END LOOP;
END USP_ListadoPaisesCaidos;
/

-- EXEC USP_ListadoTipoPersonasCaidas
create or replace NONEDITIONABLE PROCEDURE USP_GuardarPaises(
    nOpcion             IN INT DEFAULT 0,
    nId_Tp_Persona      IN INT DEFAULT 0,
    cTipo_Persona       IN VARCHAR2 DEFAULT '',
    cFecha_Modificacion IN DATE DEFAULT SYSDATE,
    cModificado_Por     IN VARCHAR2
)
AS
    xCodigo INT := 0;
    fFecha  DATE;
    empleado varchar2(50) := NULL;
BEGIN
    fFecha := SYSDATE;
    SELECT 'X' INTO empleado FROM hr.tb_usuario
    where usuario = cModificado_Por;

IF empleado is not null then
    IF nOpcion = 1 THEN -- Nuevo Registro
        INSERT INTO tb_TIPO_CLIENTE (TIPO_PERSONA,ESTADO)
        VALUES (cTipo_Persona,1);
        --dbms_output.put_line('salida insert');
    ELSE -- Actualizar registro
        UPDATE tb_TIPO_CLIENTE
        SET
            TIPO_PERSONA = cTipo_Persona,
            FECHA_MODIFICACION = cFecha_Modificacion,
            MODIFICADO_POR = cModificado_Por
        WHERE 
            ID_TP_PERSONA = nId_Tp_Persona;
        --dbms_output.put_line('salida update');
    END IF;
end if;
commit;
END USP_GuardarPaises;

CREATE OR REPLACE PROCEDURE USP_EliminarPaises(
    nID_TP_PERSONA IN INT DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TIPO_CLIENTE
    SET ESTADO = 0
    WHERE ID_TP_PERSONA = nID_TP_PERSONA;
END USP_EliminarPaises;
/

CREATE OR REPLACE PROCEDURE USP_LevantarPaises(
    nID_TP_PERSONA IN INT DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TIPO_CLIENTE
    SET ESTADO = 1
    WHERE ID_TP_PERSONA = nID_TP_PERSONA;
END USP_LevantarPaises;
/



