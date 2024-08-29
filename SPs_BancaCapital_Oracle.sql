/* PROCEDIMIENTOS ALMACENADOS PL/SQL */

CREATE OR REPLACE PROCEDURE USP_LOGIN (
    nUsuario    IN VARCHAR2,
    nContraseña IN VARCHAR2
)
AS
BEGIN
    FOR rec IN (
        SELECT
            ID_PERSONA,
            NOMBRE,
            APE_PATE,
            APE_MATE,
            FECHA_NAC,
            DIRECCION_RES,
            TEL_CEL,
            TEL_FIJO,
            CORREO_ELECTRONICO,
            SEXO,
            NUM_IDENTIFICACION,
            FECHA_EXPIRACION_IDE,
            CARGO_TRABAJO,
            ID_USER,
            USUARIO,
            CONTRASEÑA,
            ADMINISTRADOR,
            PRESTAMOS,
            CUENTAS,
            TARJETAS,
            ESTADO
        FROM V_LOGIN
        WHERE USUARIO = nUsuario AND CONTRASEÑA = nContraseña AND ESTADO = 1 
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(
            REC.ID_PERSONA || ', ' ||
            REC.NOMBRE     || ', ' ||
            REC.APE_PATE   || ', ' ||
            REC.APE_MATE   || ', ' ||
            REC.FECHA_NAC  || ', ' ||
            REC.DIRECCION_RES || ', ' ||
            REC.TEL_CEL    || ', ' ||
            REC.TEL_FIJO   || ', ' ||
            REC.CORREO_ELECTRONICO || ', ' ||
            REC.SEXO       || ', ' ||
            REC.NUM_IDENTIFICACION || ', ' ||
            REC.FECHA_EXPIRACION_IDE || ', ' ||
            REC.CARGO_TRABAJO || ', ' ||
            REC.ID_USER    || ', ' ||
            REC.USUARIO    || ', ' ||
            REC.CONTRASEÑA || ', ' ||
            REC.ADMINISTRADOR || ', ' ||
            REC.PRESTAMOS  || ', ' ||
            REC.CUENTAS    || ', ' ||
            REC.TARJETAS   
        );
    END LOOP;
END;
/
/*
CREATE OR REPLACE FUNCTION FUNCION_LOGIN (
    nUsuario    IN VARCHAR2,
    nContraseña IN VARCHAR2
)
RETURN BOOLEAN
IS
    Respuesta VARCHAR2(1);
    Salida    BOOLEAN;
BEGIN
    SELECT 'x' INTO Respuesta
    FROM v_login
    WHERE contraseña = nContraseña
    AND usuario = nUsuario;
    
    IF Respuesta IS NOT NULL THEN
        Salida := TRUE;
    ELSE
        Salida := FALSE;
    END IF;

    RETURN Salida;
END;
/*/

/* PROCEDIMIENTOS ALMACENADOS DE TB_TIPO_CLIENTE */
--1 -N°1
CREATE OR REPLACE PROCEDURE USP_ListadoTipoCliente(
    cTexto         IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
            FECHA_CREACION,
            HORA_CREACION,
            CLIENTE
        FROM TB_TIPO_CLIENTE
        WHERE ESTADO = 1 
        AND CLIENTE LIKE '%' || cTexto || '%'
        ORDER BY ID_TP_CLIENTE DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION || ', ' || rec.HORA_CREACION || ', ' || rec.CLIENTE);
    END LOOP;
END;
/

--1 -N°2
CREATE OR REPLACE PROCEDURE USP_ListadoTipoClientesCaidos(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
            FECHA_CREACION,
            HORA_CREACION,
            CLIENTE
        FROM TB_TIPO_CLIENTE
        WHERE ESTADO = 0 AND CLIENTE LIKE '%' || cTexto || '%'
        ORDER BY ID_TP_CLIENTE DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION || ', ' || rec.HORA_CREACION || ', ' || rec.CLIENTE);
    END LOOP;
END;
/

--1 -N°3
create or replace NONEDITIONABLE PROCEDURE USP_GuardarTipoCliente(
    nOpcion             NUMBER DEFAULT 0,
    nId_Tp_Cliente      NUMBER DEFAULT 0,
    cCliente            VARCHAR2
)
AS
    cFecha_Modificacion DATE DEFAULT SYSDATE;
    cModificado_Por     VARCHAR2(60) := NULL;
    xCodigo             NUMBER := 0;
    fFecha              DATE;
    empleado            varchar2(50) := NULL;
BEGIN
    SELECT 'X' INTO empleado FROM tb_usuario WHERE usuario = cModificado_Por;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        empleado := NULL;
        
    IF nOpcion = 1 THEN -- Nuevo Registro
        INSERT INTO TB_TIPO_CLIENTE (CLIENTE, ESTADO)
        VALUES (cCliente, 1);
        --dbms_output.put_line(cTipo_Persona);
    ELSE  -- Actualizar registro
        UPDATE TB_TIPO_CLIENTE
        SET
            CLIENTE = cCliente,
            FECHA_MODIFICACION = cFecha_Modificacion,
            MODIFICADO_POR = cModificado_Por
        WHERE 
            ID_TP_CLIENTE = nId_Tp_Cliente;
        --dbms_output.put_line('salida update');
end if;
commit;
END;
/

--1 -N°4
CREATE OR REPLACE PROCEDURE USP_EliminarTipoCliente(
    nID_TP_CLIENTE IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_TIPO_CLIENTE
    SET ESTADO = 0
    WHERE ID_TP_CLIENTE = nID_TP_CLIENTE;
END;
/

--1 -N°5
CREATE OR REPLACE PROCEDURE USP_LevantarTipoCliente(
    nID_TP_CLIENTE IN INT DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_TIPO_CLIENTE
    SET ESTADO = 1
    WHERE ID_TP_CLIENTE = nID_TP_CLIENTE;
END;
/
-- TERMINADO

-----------------------------------------------------------------------
--2 -N°6
/* PROCEDIMIENTOS ALMACENADOS DE TB_PAISES */
CREATE OR REPLACE PROCEDURE USP_ListadoPaises(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
            FECHA_CREACION,
            HORA_CREACION,
            NOM_PAIS,
            CODIGO_PAIS
        FROM TB_PAISES 
        WHERE ESTADO = 1 
        AND (
             NOM_PAIS    LIKE '%' || cTexto || '%' OR
             CODIGO_PAIS LIKE '%' || cTexto || '%'
            )
        ORDER BY ID_PAIS DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION || ', ' || rec.HORA_CREACION || ', ' || rec.NOM_PAIS || ', ' || rec.CODIGO_PAIS);
    END LOOP;
END;
/

--2 -N°7
CREATE OR REPLACE PROCEDURE USP_ListadoPaisesCaidos(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
            FECHA_CREACION,
            HORA_CREACION,
            NOM_PAIS,
            CODIGO_PAIS
        FROM TB_PAISES 
        WHERE ESTADO = 0 
        AND (
             NOM_PAIS    LIKE '%' || cTexto || '%' OR
             CODIGO_PAIS LIKE '%' || cTexto || '%'
            )
        ORDER BY ID_PAIS DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION || ', ' || rec.HORA_CREACION || ', ' || rec.NOM_PAIS || ', ' || rec.CODIGO_PAIS);
    END LOOP;
END;
/

--2 -N°8
create or replace NONEDITIONABLE PROCEDURE USP_GuardarPaises(
    nOpcion             IN NUMBER DEFAULT 0,
    nId_Pais            IN NUMBER DEFAULT 0,
    cNom_Pais           IN VARCHAR2,
    cCodigo_Pais        IN VARCHAR2
)
AS
    cFecha_Modificacion DATE DEFAULT SYSDATE;
    cModificado_Por     VARCHAR2(60) := NULL;
    xCodigo NUMBER := 0;
    fFecha  DATE;
    empleado varchar2(50) := NULL;
BEGIN
    SELECT 'X' INTO empleado FROM tb_usuario WHERE usuario = cModificado_Por;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        empleado := NULL;


    IF nOpcion = 1 THEN -- Nuevo Registro
        INSERT INTO TB_PAISES (NOM_PAIS,CODIGO_PAIS,ESTADO)
        VALUES (cNom_Pais,cCodigo_Pais,1);
        --dbms_output.put_line('salida insert');
    ELSE -- Actualizar registro
        UPDATE TB_PAISES
        SET
            NOM_PAIS           = cNom_Pais,
            CODIGO_PAIS        = cCodigo_Pais,
            FECHA_MODIFICACION = cFecha_Modificacion,
            MODIFICADO_POR     = cModificado_Por
        WHERE
            ID_PAIS = nId_Pais;
        --dbms_output.put_line('salida update');
end if;
commit;
END;
/

--2 -N°9
CREATE OR REPLACE PROCEDURE USP_EliminarPaises(
    nID_PAIS IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_PAISES
    SET ESTADO = 0
    WHERE ID_PAIS = nID_PAIS;
END;
/

--2 -N°10
CREATE OR REPLACE PROCEDURE USP_LevantarPaises(
    nID_PAIS IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_PAISES
    SET ESTADO = 1
    WHERE ID_PAIS = nID_PAIS;
END;
/
-- TERMINADO

-----------------------------------------------------
--3 -N°11
/* PROCEDIMIENTOS ALMACENADOS DE TB_TIPO_IDENTIFICACION */
CREATE OR REPLACE PROCEDURE USP_ListadoTipoIdentificacion(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
            FECHA_CREACION,
            HORA_CREACION,
            NOM_IDENTIFICACION
        FROM TB_TIPO_IDENTIFICACION 
        WHERE ESTADO = 1 
        AND NOM_IDENTIFICACION LIKE '%' || cTexto || '%'
        ORDER BY ID_IDENTIFICACION DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION || ', ' || 
        rec.HORA_CREACION || ', ' || rec.NOM_IDENTIFICACION);
    END LOOP;
END;
/

--3 -N°12
CREATE OR REPLACE PROCEDURE USP_ListadoTipoIdentificacionCaidos(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
            FECHA_CREACION,
            HORA_CREACION,
            NOM_IDENTIFICACION
        FROM TB_TIPO_IDENTIFICACION 
        WHERE ESTADO = 0
        AND NOM_IDENTIFICACION LIKE '%' || cTexto || '%'
        ORDER BY ID_IDENTIFICACION DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION || ', ' 
        || rec.HORA_CREACION || ', ' || rec.NOM_IDENTIFICACION);
    END LOOP;
END;
/

--3 -N°13
create or replace NONEDITIONABLE PROCEDURE USP_GuardarTipoIdentificacion(
    nOpcion             IN NUMBER DEFAULT 0,
    nId_Identificacion  IN NUMBER DEFAULT 0,
    cNom_Identificacion IN VARCHAR2
)
AS
    cFecha_Modificacion DATE DEFAULT SYSDATE;
    cModificado_Por     VARCHAR2(60) := NULL;
    xCodigo INT := 0;
    fFecha  DATE;
    empleado varchar2(50) := NULL;
BEGIN
    SELECT 'X' INTO empleado FROM tb_usuario WHERE usuario = cModificado_Por;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        empleado := NULL;


    IF nOpcion = 1 THEN -- Nuevo Registro
        INSERT INTO TB_TIPO_IDENTIFICACION (NOM_IDENTIFICACION,ESTADO)
        VALUES (cNom_Identificacion,1);
        --dbms_output.put_line('salida insert');
    ELSE -- Actualizar registro
        UPDATE TB_TIPO_IDENTIFICACION
        SET
            NOM_IDENTIFICACION = cNom_Identificacion,
            FECHA_MODIFICACION = cFecha_Modificacion,
            MODIFICADO_POR     = cModificado_Por
        WHERE
            ID_IDENTIFICACION  = nId_Identificacion;
        --dbms_output.put_line('salida update');
end if;
commit;
END;
/

--3 -N°14
CREATE OR REPLACE PROCEDURE USP_EliminarTipoIdentificacion(
    nID_IDENTIFICACION IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_TIPO_IDENTIFICACION
    SET ESTADO = 0
    WHERE ID_IDENTIFICACION = nID_IDENTIFICACION;
END;
/

--3 -N°15
CREATE OR REPLACE PROCEDURE USP_LevantarTipoIdentificacion(
    nID_IDENTIFICACION IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_TIPO_IDENTIFICACION
    SET ESTADO = 1
    WHERE ID_IDENTIFICACION = nID_IDENTIFICACION;
END;
/
--TERMINADO

-----------------------------------------------------
--4 -N°16
/* PROCEDIMIENTOS ALMACENADOS DE TB_ESTADOS_CIVILES */
CREATE OR REPLACE PROCEDURE USP_ListadoEstadosCiviles(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
            FECHA_CREACION,
            HORA_CREACION,
            NOM_ESTADO_CIVIL
        FROM TB_ESTADOS_CIVILES
        WHERE ESTADO = 1 
        AND NOM_ESTADO_CIVIL LIKE '%' || cTexto || '%'
        ORDER BY ID_ESTADO_CIVIL DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION || ', ' || 
        rec.HORA_CREACION || ', ' || rec.NOM_ESTADO_CIVIL);
    END LOOP;
END;
/

--4 -N°17
CREATE OR REPLACE PROCEDURE USP_ListadoEstadosCivilesCaidos(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
            FECHA_CREACION,
            HORA_CREACION,
            NOM_ESTADO_CIVIL
        FROM TB_ESTADOS_CIVILES
        WHERE ESTADO = 0 
        AND NOM_ESTADO_CIVIL LIKE '%' || cTexto || '%'
        ORDER BY ID_ESTADO_CIVIL DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION || ', ' || 
        rec.HORA_CREACION || ', ' || rec.NOM_ESTADO_CIVIL);
    END LOOP;
END;
/

--4 -N°18
create or replace NONEDITIONABLE PROCEDURE USP_GuardarEstadosCiviles(
    nOpcion             IN NUMBER DEFAULT 0,
    nId_EstadoCivil     IN NUMBER DEFAULT 0,
    cNom_EstadoCivil    IN VARCHAR2
)
AS
    cFecha_Modificacion DATE DEFAULT SYSDATE;
    cModificado_Por     VARCHAR2(60) := NULL;
    xCodigo INT := 0;
    fFecha  DATE;
    empleado varchar2(50) := NULL;
BEGIN
    SELECT 'X' INTO empleado FROM tb_usuario WHERE usuario = cModificado_Por;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        empleado := NULL;


    IF nOpcion = 1 THEN -- Nuevo Registro
        INSERT INTO TB_ESTADOS_CIVILES (NOM_ESTADO_CIVIL,ESTADO)
        VALUES (cNom_EstadoCivil,1);
        --dbms_output.put_line('salida insert');
    ELSE -- Actualizar registro
        UPDATE TB_ESTADOS_CIVILES
        SET
            NOM_ESTADO_CIVIL   = cNom_EstadoCivil,
            FECHA_MODIFICACION = cFecha_Modificacion,
            MODIFICADO_POR     = cModificado_Por
        WHERE
            ID_ESTADO_CIVIL    = nId_EstadoCivil;
        --dbms_output.put_line('salida update');
end if;
commit;
END;
/

--4 -N°19
CREATE OR REPLACE PROCEDURE USP_EliminarEstadosCiviles(
    nId_EstadoCivil IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_ESTADOS_CIVILES
    SET ESTADO = 0
    WHERE ID_ESTADO_CIVIL = nId_EstadoCivil;
END;
/

--4 -N°20
CREATE OR REPLACE PROCEDURE USP_LevantarEstadosCiviles(
    nId_EstadoCivil IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_ESTADOS_CIVILES
    SET ESTADO = 1
    WHERE ID_ESTADO_CIVIL = nId_EstadoCivil;
END;
/
--TERMINADO

-----------------------------------------------------
--5 -N°21
/* PROCEDIMIENTOS ALMACENADOS DE TB_MONEDAS */
CREATE OR REPLACE PROCEDURE USP_ListadoMonedas(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              FECHA_CREACION,
              HORA_CREACION,
              NOM_MONEDA
        FROM  TB_MONEDAS
        WHERE ESTADO = 1 
        AND   NOM_MONEDA LIKE '%' || cTexto || '%'
        ORDER BY ID_MONEDA DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION || ', ' || 
        rec.HORA_CREACION || ', ' || rec.NOM_MONEDA);
    END LOOP;
END;
/

--5 -N°22
CREATE OR REPLACE PROCEDURE USP_ListadoMonedasCaidos(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              FECHA_CREACION,
              HORA_CREACION,
              NOM_MONEDA
        FROM  TB_MONEDAS
        WHERE ESTADO = 0 
        AND   NOM_MONEDA LIKE '%' || cTexto || '%'
        ORDER BY ID_MONEDA DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION || ', ' || 
        rec.HORA_CREACION || ', ' || rec.NOM_MONEDA);
    END LOOP;
END;
/

--5 -N°23
create or replace NONEDITIONABLE PROCEDURE USP_GuardarMonedas(
    nOpcion     IN NUMBER DEFAULT 0,
    nId_Moneda  IN NUMBER,
    cNom_Moneda IN VARCHAR2
)
AS
    cFecha_Modificacion DATE DEFAULT SYSDATE;
    cModificado_Por     VARCHAR2(60) := NULL;
    xCodigo INT := 0;
    fFecha  DATE;
    empleado varchar2(50) := NULL;
BEGIN
    SELECT 'X' INTO empleado FROM tb_usuario WHERE usuario = cModificado_Por;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        empleado := NULL;

    IF nOpcion = 1 THEN -- Nuevo Registro
        INSERT INTO TB_MONEDAS (NOM_MONEDA,ESTADO)
        VALUES (cNom_Moneda,1);
        --dbms_output.put_line('salida insert');
    ELSE -- Actualizar registro
        UPDATE TB_MONEDAS
        SET
            NOM_MONEDA         = cNom_Moneda,
            FECHA_MODIFICACION = cFecha_Modificacion,
            MODIFICADO_POR     = cModificado_Por
        WHERE
            ID_MONEDA          = nId_Moneda;
        --dbms_output.put_line('salida update');
END IF;
commit;
END;
/

--5 -N°24
CREATE OR REPLACE PROCEDURE USP_EliminarMonedas(
    nId_Moneda IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_MONEDAS
    SET ESTADO = 0
    WHERE ID_MONEDA = nId_Moneda;
END;
/

--5 -N°25
CREATE OR REPLACE PROCEDURE USP_LevantarMonedas(
    nId_Moneda IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_MONEDAS
    SET ESTADO = 1
    WHERE ID_MONEDA = nId_Moneda;
END;
/
--TERMINADO

-----------------------------------------------------
--6 -N°26
/* PROCEDIMIENTOS ALMACENADOS DE TB_RANGO_INGRESO */
CREATE OR REPLACE PROCEDURE USP_ListadoRangoIngreso(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.RANGO,
              B.NOM_MONEDA   
        FROM  TB_RANGO_INGRESO A
        INNER JOIN TB_MONEDAS B ON A.ID_MONEDA = B.ID_MONEDA
        WHERE A.ESTADO = 1
        AND   (
               A.RANGO      LIKE '%' || cTexto || '%' OR
               B.NOM_MONEDA LIKE '%' || cTexto || '%'
               )
        ORDER BY A.ID_RANGO_INGRESO DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION || ', ' || 
        rec.HORA_CREACION || ', ' || rec.RANGO || ', ' || rec.NOM_MONEDA
        );
    END LOOP;
END;
/

--6 -N°27
CREATE OR REPLACE PROCEDURE USP_ListadoRangoIngresoCaido(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.RANGO,
              B.NOM_MONEDA   
        FROM  TB_RANGO_INGRESO A
        INNER JOIN TB_MONEDAS B ON A.ID_MONEDA = B.ID_MONEDA
        WHERE A.ESTADO = 0
        AND   (
               A.RANGO      LIKE '%' || cTexto || '%' OR
               B.NOM_MONEDA LIKE '%' || cTexto || '%'
               )
        ORDER BY A.ID_RANGO_INGRESO DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION || ', ' || 
        rec.HORA_CREACION || ', ' || rec.RANGO || ', ' || rec.NOM_MONEDA
        );
    END LOOP;
END;
/

--6 -N°28
create or replace NONEDITIONABLE PROCEDURE USP_GuardarRangoIngreso(
    nOpcion             IN NUMBER DEFAULT 0,
    nId_RangoIngreso    IN NUMBER DEFAULT 0,
    nId_Moneda          IN NUMBER DEFAULT 0,
    cRango              IN VARCHAR2
)
AS
    cFecha_Modificacion DATE DEFAULT SYSDATE;
    cModificado_Por     VARCHAR2(60) := NULL;
    xCodigo INT := 0;
    fFecha  DATE;
    empleado varchar2(50) := NULL;
BEGIN
    SELECT 'X' INTO empleado FROM tb_usuario WHERE usuario = cModificado_Por;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        empleado := NULL;


    IF nOpcion = 1 THEN -- Nuevo Registro
        INSERT INTO TB_RANGO_INGRESO (ID_MONEDA,RANGO,ESTADO)
        VALUES (nId_Moneda,cRango,1);
        --dbms_output.put_line('salida insert');
    ELSE -- Actualizar registro
        UPDATE TB_RANGO_INGRESO
        SET
            ID_MONEDA          = nId_Moneda,
            RANGO              = cRango,
            FECHA_MODIFICACION = cFecha_Modificacion,
            MODIFICADO_POR     = cModificado_Por
        WHERE
            ID_RANGO_INGRESO   = nId_RangoIngreso;
        --dbms_output.put_line('salida update');
end if;
commit;
END;
/

--6 -N°29
CREATE OR REPLACE PROCEDURE USP_EliminarRangoIngreso(
    nId_RangoIngreso IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_RANGO_INGRESO
    SET ESTADO = 0
    WHERE ID_RANGO_INGRESO = nId_RangoIngreso;
END;
/

--6 -N°30
CREATE OR REPLACE PROCEDURE USP_LevantarRangoIngreso(
    nId_RangoIngreso IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_RANGO_INGRESO
    SET ESTADO = 1
    WHERE ID_RANGO_INGRESO = nId_RangoIngreso;
END;
/
--TERMINADO

-----------------------------------------------------

create or replace NONEDITIONABLE PROCEDURE USP_GuardarDepartamento(
    nOpcion             NUMBER DEFAULT 0,
    nId_Depto           NUMBER DEFAULT 0,
    cDepartamento       VARCHAR2
)
AS
    cFecha_Modificacion DATE DEFAULT SYSDATE;
    cModificado_Por     VARCHAR2(60) := NULL;
    xCodigo INT := 0;
    fFecha  DATE;
    empleado varchar2(50) := NULL;
BEGIN
    SELECT 'X' INTO empleado FROM tb_usuario WHERE usuario = cModificado_Por;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        empleado := NULL;
        
    

    IF nOpcion = 1 THEN -- Nuevo Registro
        INSERT 
        INTO 
        TB_DEPARTAMENTOS(
                  DEPARTAMENTO,
                  ESTADO
                )
        VALUES   (
                  cDepartamento,
                  1
                );
        --dbms_output.put_line('salida insert');
    ELSE -- Actualizar registro
        UPDATE TB_DEPARTAMENTOS
        SET
             ID_DEPTO           = nId_Depto,
             DEPARTAMENTO       = cDepartamento,
             FECHA_MODIFICACION = cFecha_Modificacion,
             MODIFICADO_POR     = cModificado_Por
        WHERE
             ID_DEPTO    = nId_Depto;
        --dbms_output.put_line('salida update');
end if;
commit;
END;
/

-----------------------------------------------------
-----------------------------------------------------
EXEC USP_Guardar_SUCURSAL_DEPTO(1,1,4);

create or replace NONEDITIONABLE PROCEDURE USP_Guardar_SUCURSAL_DEPTO(
    nOpcion      IN NUMBER DEFAULT 0,
    nId_Sucursal IN NUMBER DEFAULT 0,
    nId_Depto    IN NUMBER DEFAULT 0
)
AS
    cFecha_Modificacion DATE DEFAULT SYSDATE;
    xCodigo INT := 0;
    fFecha  DATE;
    empleado varchar2(50) := NULL;
BEGIN

    IF nOpcion = 1 THEN -- Nuevo Registro
        INSERT INTO TB_SUCURSAL_DEPTO(
        ID_DEPTO,
        ID_SUCURSAL
        )
        VALUES (
        nId_Depto,
        nId_Sucursal
        );
        --dbms_output.put_line('salida insert');
    ELSE -- Actualizar registro
        UPDATE TB_SUCURSAL_DEPTO
        SET
            ID_DEPTO           = nId_Depto,
            ID_SUCURSAL        = nId_Sucursal,
            FECHA_MODIFICACION = cFecha_Modificacion
        WHERE
            ID_DEPTO           = nId_Depto OR
            ID_SUCURSAL        = nId_Sucursal;
        --dbms_output.put_line('salida update');
end if;
commit;
END;
/

-----------------------------------------------------
--7 -N°31
/* PROCEDIMIENTOS ALMACENADOS DE TB_TIPO_SUCURSAL */
CREATE OR REPLACE PROCEDURE USP_ListadoTipoSucursal(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              FECHA_CREACION,
              HORA_CREACION,
              TIPO_SUCURSAL
        FROM  TB_TIPO_SUCURSAL
        WHERE ESTADO = 1 
        AND   TIPO_SUCURSAL     LIKE '%' || cTexto || '%'
        ORDER BY ID_TP_SUCURSAL DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION || ', ' || 
        rec.HORA_CREACION || ', ' || rec.TIPO_SUCURSAL);
    END LOOP;
END;
/

--7 -N°32
CREATE OR REPLACE PROCEDURE USP_ListadoTipoSucursalCaida(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              FECHA_CREACION,
              HORA_CREACION,
              TIPO_SUCURSAL
        FROM  TB_TIPO_SUCURSAL
        WHERE ESTADO = 0
        AND   TIPO_SUCURSAL     LIKE '%' || cTexto || '%'
        ORDER BY ID_TP_SUCURSAL DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION || ', ' || 
        rec.HORA_CREACION || ', ' || rec.TIPO_SUCURSAL);
    END LOOP;
END;
/

--7 -N°33
create or replace NONEDITIONABLE PROCEDURE USP_GuardarTipoSucursal(
    nOpcion             IN NUMBER DEFAULT 0,
    nId_TipoSucursal    IN NUMBER DEFAULT 0,
    cTipoSucursal       IN VARCHAR2
)
AS
    cFecha_Modificacion DATE DEFAULT SYSDATE;
    cModificado_Por     VARCHAR2(60) := NULL;
    xCodigo INT := 0;
    fFecha  DATE;
    empleado varchar2(50) := NULL;
BEGIN
    SELECT 'X' INTO empleado FROM tb_usuario WHERE usuario = cModificado_Por;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        empleado := NULL;


    IF nOpcion = 1 THEN -- Nuevo Registro
        INSERT INTO TB_TIPO_SUCURSAL (TIPO_SUCURSAL,ESTADO)
        VALUES (cTipoSucursal,1);
        --dbms_output.put_line('salida insert');
    ELSE -- Actualizar registro
        UPDATE TB_TIPO_SUCURSAL
        SET
            ID_TP_SUCURSAL     = nId_TipoSucursal,
            TIPO_SUCURSAL      = cTipoSucursal,
            FECHA_MODIFICACION = cFecha_Modificacion,
            MODIFICADO_POR     = cModificado_Por
        WHERE
            ID_TP_SUCURSAL     = nId_TipoSucursal;
        --dbms_output.put_line('salida update');
end if;
commit;
END;
/

--7 -N°34
CREATE OR REPLACE PROCEDURE USP_EliminarTipoSucursal(
    nId_TipoSucursal IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_TIPO_SUCURSAL
    SET ESTADO = 0
    WHERE ID_TP_SUCURSAL = nId_TipoSucursal;
END;
/

--7 -N°35
CREATE OR REPLACE PROCEDURE USP_LevantarTipoSucursal(
    nId_TipoSucursal IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_TIPO_SUCURSAL
    SET ESTADO = 1
    WHERE ID_TP_SUCURSAL = nId_TipoSucursal;
END;
/
--TERMINADO

-----------------------------------------------------
/* PROCEDIMIENTOS ALMACENADOS DE TB_TIPO_SUCURSAL */
--8 -N°36
CREATE OR REPLACE PROCEDURE USP_ListadoSucursales(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.CODIGO_SUCURSAL,
              A.DIRECCION,
              B.TIPO_SUCURSAL
        FROM  TB_SUCURSAL A
        INNER JOIN TB_TIPO_SUCURSAL B ON A.ID_TP_SUCURSAL = B.ID_TP_SUCURSAL
        WHERE A.ESTADO = 1
        AND   (
               A.CODIGO_SUCURSAL LIKE '%' || cTexto || '%' OR
               A.DIRECCION       LIKE '%' || cTexto || '%' OR
               B.TIPO_SUCURSAL   LIKE '%' || cTexto || '%'
               )
        ORDER BY A.ID_SUCURSAL DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION || ', ' || 
        rec.HORA_CREACION  || ', ' || rec.CODIGO_SUCURSAL || ', ' || rec.DIRECCION || ', ' || rec.TIPO_SUCURSAL
        );
    END LOOP;
END;
/

--8 -N°37
CREATE OR REPLACE PROCEDURE USP_ListadoSucursalesCaidas(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.CODIGO_SUCURSAL,
              A.DIRECCION,
              B.TIPO_SUCURSAL
        FROM  TB_SUCURSAL A
        INNER JOIN TB_TIPO_SUCURSAL B ON A.ID_TP_SUCURSAL = B.ID_TP_SUCURSAL
        WHERE A.ESTADO = 0
        AND   (
               A.CODIGO_SUCURSAL LIKE '%' || cTexto || '%' OR
               A.DIRECCION       LIKE '%' || cTexto || '%' OR
               B.TIPO_SUCURSAL   LIKE '%' || cTexto || '%'
               )
        ORDER BY A.ID_SUCURSAL DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION || ', ' || 
        rec.HORA_CREACION  || ', ' || rec.CODIGO_SUCURSAL || ', ' || rec.DIRECCION || ', ' || rec.TIPO_SUCURSAL
        );
    END LOOP;
END;
/

--8 -N°38
create or replace NONEDITIONABLE PROCEDURE USP_GuardarSucursal(
    nOpcion             IN NUMBER DEFAULT 0,
    nId_Sucursal        IN NUMBER DEFAULT 0,
    nId_TipoSucursal    IN NUMBER DEFAULT 0,
    cDireccion          IN VARCHAR2
)
AS
    cFecha_Modificacion DATE DEFAULT SYSDATE;
    cModificado_Por     VARCHAR2(60) := NULL;
    xCodigo INT := 0;
    fFecha  DATE;
    empleado varchar2(50) := NULL;
BEGIN
    SELECT 'X' INTO empleado FROM tb_usuario WHERE usuario = cModificado_Por;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        empleado := NULL;


    IF nOpcion = 1 THEN -- Nuevo Registro
        INSERT INTO TB_SUCURSAL (ID_TP_SUCURSAL,DIRECCION,ESTADO)
        VALUES (nId_TipoSucursal,cDireccion,1);
        --dbms_output.put_line('salida insert');
    ELSE -- Actualizar registro
        UPDATE TB_SUCURSAL
        SET
            ID_TP_SUCURSAL     = nId_TipoSucursal,
            DIRECCION          = cDireccion,
            FECHA_MODIFICACION = cFecha_Modificacion,
            MODIFICADO_POR     = cModificado_Por
        WHERE
            ID_SUCURSAL        = nId_Sucursal;
        --dbms_output.put_line('salida update');
end if;
commit;
END;
/

--8 -N°39
CREATE OR REPLACE PROCEDURE USP_EliminarSucursal(
    nId_Sucursal IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_SUCURSAL
    SET ESTADO = 0
    WHERE ID_SUCURSAL = nId_Sucursal;
END;
/

--8 -N°40
CREATE OR REPLACE PROCEDURE USP_LevantarSucursal(
    nId_Sucursal IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_SUCURSAL
    SET ESTADO = 1
    WHERE ID_SUCURSAL = nId_Sucursal;
END;
/
--TERMINADO

-----------------------------------------------------
/* PROCEDIMIENTOS ALMACENADOS DE TB_CARGO_EMPLEADO */
--9 -N°41
CREATE OR REPLACE PROCEDURE USP_ListadoCargoEmpleados(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              FECHA_CREACION,
              HORA_CREACION,
              NOM_CARGO
        FROM  TB_CARGO_EMPLEADO
        WHERE ESTADO = 1
        AND   NOM_CARGO LIKE '%' || cTexto || '%'
        ORDER BY ID_CARGO_EMPLEADO DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION || ', ' || 
        rec.HORA_CREACION || ', ' || rec.NOM_CARGO);
    END LOOP;
END;
/

--9 -N°42
CREATE OR REPLACE PROCEDURE USP_ListadoCargoEmpleadosCaidos(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              FECHA_CREACION,
              HORA_CREACION,
              NOM_CARGO
        FROM  TB_CARGO_EMPLEADO
        WHERE ESTADO = 0
        AND   NOM_CARGO LIKE '%' || cTexto || '%'
        ORDER BY ID_CARGO_EMPLEADO DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION || ', ' || 
        rec.HORA_CREACION || ', ' || rec.NOM_CARGO);
    END LOOP;
END;
/

--9 -N°43
create or replace NONEDITIONABLE PROCEDURE USP_GuardarCargoEmpleados(
    nOpcion             IN NUMBER DEFAULT 0,
    nId_CargoEmpleado   IN NUMBER DEFAULT 0,
    cNomCargo           IN VARCHAR2
)
AS
    cFecha_Modificacion DATE DEFAULT SYSDATE;
    cModificado_Por     VARCHAR2(60) := NULL;
    xCodigo INT := 0;
    fFecha  DATE;
    empleado varchar2(50) := NULL;
BEGIN
    SELECT 'X' INTO empleado FROM tb_usuario WHERE usuario = cModificado_Por;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        empleado := NULL;


    IF nOpcion = 1 THEN -- Nuevo Registro
        INSERT INTO TB_CARGO_EMPLEADO (NOM_CARGO,ESTADO)
        VALUES (cNomCargo,1);
        --dbms_output.put_line('salida insert');
    ELSE -- Actualizar registro
        UPDATE TB_CARGO_EMPLEADO
        SET
            NOM_CARGO          = cNomCargo,
            FECHA_MODIFICACION = cFecha_Modificacion,
            MODIFICADO_POR     = cModificado_Por
        WHERE
            ID_CARGO_EMPLEADO  = nId_CargoEmpleado;
        --dbms_output.put_line('salida update');
end if;
commit;
END;
/

--9 -N°44
CREATE OR REPLACE PROCEDURE USP_EliminarCargoEmpleados(
    nId_CargoEmpleado IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_CARGO_EMPLEADO
    SET ESTADO = 0
    WHERE ID_CARGO_EMPLEADO = nId_CargoEmpleado;
END;
/

--9 -N°45
CREATE OR REPLACE PROCEDURE USP_LevantarCargoEmpleados(
    nId_CargoEmpleado IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_CARGO_EMPLEADO
    SET ESTADO = 1
    WHERE ID_CARGO_EMPLEADO = nId_CargoEmpleado;
END;
/
--TERMINADO

-----------------------------------------------------
/* PROCEDIMIENTOS ALMACENADOS DE TB_PERSONAS */
--10 -N°46 -N°1
CREATE OR REPLACE PROCEDURE USP_ListadoPersonasClientes(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.ID_PERSONA,
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.NOMBRE,
              A.APE_PATE,
              A.APE_MATE,
              A.FECHA_NAC,
              A.DIRECCION_RES,
              A.TEL_CEL,
              A.TEL_FIJO,
              A.CORREO_ELECTRONICO,
              A.SEXO,
              A.NUM_IDENTIFICACION,
              A.CARGO_TRABAJO,
              A.EMPLEADO,
              
              B.ID_TP_CLIENTE,
              B.CLIENTE,
              
              C.ID_IDENTIFICACION,
              C.NOM_IDENTIFICACION,
              
              D.ID_PAIS,
              D.NOM_PAIS,
              
              E.ID_ESTADO_CIVIL,
              E.NOM_ESTADO_CIVIL,
              
              F.ID_RANGO_INGRESO,
              F.RANGO,
              
              G.ID_MONEDA,
              G.NOM_MONEDA
              
        FROM  TB_PERSONAS A
        INNER JOIN TB_TIPO_CLIENTE        B ON A.ID_TP_CLIENTE     = B.ID_TP_CLIENTE
        INNER JOIN TB_TIPO_IDENTIFICACION C ON A.ID_IDENTIFICACION = C.ID_IDENTIFICACION
        INNER JOIN TB_PAISES              D ON A.ID_PAIS           = D.ID_PAIS
        INNER JOIN TB_ESTADOS_CIVILES     E ON A.ID_ESTADO_CIVIL   = E.ID_ESTADO_CIVIL
        INNER JOIN TB_RANGO_INGRESO       F ON A.ID_RANGO_INGRESO  = F.ID_RANGO_INGRESO
        INNER JOIN TB_MONEDAS             G ON A.ID_MONEDA         = G.ID_MONEDA
        WHERE A.ESTADO = 1 AND A.EMPLEADO = 0
        AND   (
               A.NOMBRE               LIKE '%' || cTexto || '%' OR
               A.APE_PATE             LIKE '%' || cTexto || '%' OR
               A.APE_MATE             LIKE '%' || cTexto || '%' OR
               A.FECHA_NAC            LIKE '%' || cTexto || '%' OR
               A.DIRECCION_RES        LIKE '%' || cTexto || '%' OR
               A.TEL_CEL              LIKE '%' || cTexto || '%' OR
               A.TEL_FIJO             LIKE '%' || cTexto || '%' OR
               A.CORREO_ELECTRONICO   LIKE '%' || cTexto || '%' OR
               A.SEXO                 LIKE '%' || cTexto || '%' OR
               A.NUM_IDENTIFICACION   LIKE '%' || cTexto || '%' OR
               A.CARGO_TRABAJO        LIKE '%' || cTexto || '%' OR
               A.EMPLEADO             LIKE '%' || cTexto || '%' OR
               
               B.CLIENTE              LIKE '%' || cTexto || '%' OR
              
               C.NOM_IDENTIFICACION   LIKE '%' || cTexto || '%' OR
              
               D.NOM_PAIS             LIKE '%' || cTexto || '%' OR
              
               E.NOM_ESTADO_CIVIL     LIKE '%' || cTexto || '%' OR
              
               F.RANGO                LIKE '%' || cTexto || '%' OR
              
               G.NOM_MONEDA           LIKE '%' || cTexto || '%'
              )
        ORDER BY A.ID_PERSONA DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION  || ', ' || rec.HORA_CREACION || ', ' || rec.NOMBRE        
        || ', ' || rec.APE_PATE           || ', ' || rec.APE_MATE             || ', ' || rec.FECHA_NAC          || ', ' || rec.DIRECCION_RES 
        || ', ' || rec.TEL_CEL            || ', ' || rec.TEL_FIJO             || ', ' || rec.CORREO_ELECTRONICO               
        || ', ' || rec.NUM_IDENTIFICACION || ', ' || rec.CARGO_TRABAJO                   
        || ', ' || rec.CLIENTE            || ', ' || rec.NOM_IDENTIFICACION   || ', ' || rec.NOM_PAIS           || ', ' || rec.NOM_ESTADO_CIVIL    
        || ', ' || rec.RANGO              || ', ' || rec.NOM_MONEDA
        );
    END LOOP;
END;
/

--10 -N°47 -N°2
CREATE OR REPLACE PROCEDURE USP_ListadoPersonasEmpleadas(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.NOMBRE,
              A.APE_PATE,
              A.APE_MATE,
              A.FECHA_NAC,
              A.DIRECCION_RES,
              A.TEL_CEL,
              A.TEL_FIJO,
              A.CORREO_ELECTRONICO,
              A.SEXO,
              A.NUM_IDENTIFICACION,
              A.FECHA_EXPIRACION_IDE,
              A.CARGO_TRABAJO,
              A.EMPLEADO,
              
              B.CLIENTE,
              
              C.NOM_IDENTIFICACION,
              
              D.NOM_PAIS,
              
              E.NOM_ESTADO_CIVIL,
              
              F.RANGO,
              
              G.NOM_MONEDA,
              
              H.DIRECCION AS DIRECCION_SUC
              
        FROM  TB_PERSONAS A
        INNER JOIN TB_TIPO_CLIENTE        B ON A.ID_TP_CLIENTE     = B.ID_TP_CLIENTE
        INNER JOIN TB_TIPO_IDENTIFICACION C ON A.ID_IDENTIFICACION = C.ID_IDENTIFICACION
        INNER JOIN TB_PAISES              D ON A.ID_PAIS           = D.ID_PAIS
        INNER JOIN TB_ESTADOS_CIVILES     E ON A.ID_ESTADO_CIVIL   = E.ID_ESTADO_CIVIL
        INNER JOIN TB_RANGO_INGRESO       F ON A.ID_RANGO_INGRESO  = F.ID_RANGO_INGRESO
        INNER JOIN TB_MONEDAS             G ON A.ID_MONEDA         = G.ID_MONEDA
        INNER JOIN TB_SUCURSAL            H ON A.ID_SUCURSAL       = H.ID_SUCURSAL
        WHERE A.ESTADO = 1 AND A.EMPLEADO = 1
        AND   (
               A.NOMBRE               LIKE '%' || cTexto || '%' OR
               A.APE_PATE             LIKE '%' || cTexto || '%' OR
               A.APE_MATE             LIKE '%' || cTexto || '%' OR
               A.FECHA_NAC            LIKE '%' || cTexto || '%' OR
               A.DIRECCION_RES        LIKE '%' || cTexto || '%' OR
               A.TEL_CEL              LIKE '%' || cTexto || '%' OR
               A.TEL_FIJO             LIKE '%' || cTexto || '%' OR
               A.CORREO_ELECTRONICO   LIKE '%' || cTexto || '%' OR
               A.SEXO                 LIKE '%' || cTexto || '%' OR
               A.NUM_IDENTIFICACION   LIKE '%' || cTexto || '%' OR
               A.FECHA_EXPIRACION_IDE LIKE '%' || cTexto || '%' OR
               A.CARGO_TRABAJO        LIKE '%' || cTexto || '%' OR
               A.EMPLEADO             LIKE '%' || cTexto || '%' OR
               
               B.CLIENTE              LIKE '%' || cTexto || '%' OR
              
               C.NOM_IDENTIFICACION   LIKE '%' || cTexto || '%' OR
              
               D.NOM_PAIS             LIKE '%' || cTexto || '%' OR
              
               E.NOM_ESTADO_CIVIL     LIKE '%' || cTexto || '%' OR
              
               F.RANGO                LIKE '%' || cTexto || '%' OR
              
               G.NOM_MONEDA           LIKE '%' || cTexto || '%' OR
              
               H.CODIGO_SUCURSAL      LIKE '%' || cTexto || '%' OR
               H.DIRECCION            LIKE '%' || cTexto || '%'
              )
        ORDER BY A.ID_PERSONA DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION       || ', ' || rec.HORA_CREACION      || ', ' || rec.NOMBRE        
        || ', ' || rec.APE_PATE             || ', ' || rec.APE_MATE             || ', ' || rec.FECHA_NAC          || ', ' || rec.DIRECCION_RES 
        || ', ' || rec.TEL_CEL              || ', ' || rec.TEL_FIJO             || ', ' || rec.CORREO_ELECTRONICO || ', ' || rec.SEXO              
        || ', ' || rec.NUM_IDENTIFICACION   || ', ' || rec.FECHA_EXPIRACION_IDE || ', ' || rec.CARGO_TRABAJO      || ', ' || rec.EMPLEADO           
        || ', ' || rec.CLIENTE              || ', ' || rec.NOM_IDENTIFICACION   || ', ' || rec.NOM_PAIS           || ', ' || rec.NOM_ESTADO_CIVIL    
        || ', ' || rec.RANGO                || ', ' || rec.NOM_MONEDA           || ', ' || rec.DIRECCION_SUC
        );
    END LOOP;
END;
/

--10 -N°48 -N°1
CREATE OR REPLACE PROCEDURE USP_ListadoPersonasClientesCaidas(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.NOMBRE,
              A.APE_PATE,
              A.APE_MATE,
              A.FECHA_NAC,
              A.DIRECCION_RES,
              A.TEL_CEL,
              A.TEL_FIJO,
              A.CORREO_ELECTRONICO,
              A.SEXO,
              A.NUM_IDENTIFICACION,
              A.FECHA_EXPIRACION_IDE,
              A.CARGO_TRABAJO,
              A.EMPLEADO,
              
              B.CLIENTE,
              
              C.NOM_IDENTIFICACION,
              
              D.NOM_PAIS,
              
              E.NOM_ESTADO_CIVIL,
              
              F.RANGO,
              
              G.NOM_MONEDA,
              
              H.DIRECCION AS DIRECCION_SUC
              
        FROM  TB_PERSONAS A
        INNER JOIN TB_TIPO_CLIENTE        B ON A.ID_TP_CLIENTE     = B.ID_TP_CLIENTE
        INNER JOIN TB_TIPO_IDENTIFICACION C ON A.ID_IDENTIFICACION = C.ID_IDENTIFICACION
        INNER JOIN TB_PAISES              D ON A.ID_PAIS           = D.ID_PAIS
        INNER JOIN TB_ESTADOS_CIVILES     E ON A.ID_ESTADO_CIVIL   = E.ID_ESTADO_CIVIL
        INNER JOIN TB_RANGO_INGRESO       F ON A.ID_RANGO_INGRESO  = F.ID_RANGO_INGRESO
        INNER JOIN TB_MONEDAS             G ON A.ID_MONEDA         = G.ID_MONEDA
        INNER JOIN TB_SUCURSAL            H ON A.ID_SUCURSAL       = H.ID_SUCURSAL
        WHERE A.ESTADO = 0 AND A.EMPLEADO = 0
        AND   (
               A.NOMBRE               LIKE '%' || cTexto || '%' OR
               A.APE_PATE             LIKE '%' || cTexto || '%' OR
               A.APE_MATE             LIKE '%' || cTexto || '%' OR
               A.FECHA_NAC            LIKE '%' || cTexto || '%' OR
               A.DIRECCION_RES        LIKE '%' || cTexto || '%' OR
               A.TEL_CEL              LIKE '%' || cTexto || '%' OR
               A.TEL_FIJO             LIKE '%' || cTexto || '%' OR
               A.CORREO_ELECTRONICO   LIKE '%' || cTexto || '%' OR
               A.SEXO                 LIKE '%' || cTexto || '%' OR
               A.NUM_IDENTIFICACION   LIKE '%' || cTexto || '%' OR
               A.FECHA_EXPIRACION_IDE LIKE '%' || cTexto || '%' OR
               A.CARGO_TRABAJO        LIKE '%' || cTexto || '%' OR
               A.EMPLEADO             LIKE '%' || cTexto || '%' OR
               
               B.CLIENTE              LIKE '%' || cTexto || '%' OR
              
               C.NOM_IDENTIFICACION   LIKE '%' || cTexto || '%' OR
              
               D.NOM_PAIS             LIKE '%' || cTexto || '%' OR
              
               E.NOM_ESTADO_CIVIL     LIKE '%' || cTexto || '%' OR
              
               F.RANGO                LIKE '%' || cTexto || '%' OR
              
               G.NOM_MONEDA           LIKE '%' || cTexto || '%' OR
              
               H.CODIGO_SUCURSAL      LIKE '%' || cTexto || '%' OR
               H.DIRECCION            LIKE '%' || cTexto || '%'
              )
        ORDER BY A.ID_PERSONA DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION       || ', ' || rec.HORA_CREACION      || ', ' || rec.NOMBRE        
        || ', ' || rec.APE_PATE             || ', ' || rec.APE_MATE             || ', ' || rec.FECHA_NAC          || ', ' || rec.DIRECCION_RES 
        || ', ' || rec.TEL_CEL              || ', ' || rec.TEL_FIJO             || ', ' || rec.CORREO_ELECTRONICO || ', ' || rec.SEXO              
        || ', ' || rec.NUM_IDENTIFICACION   || ', ' || rec.FECHA_EXPIRACION_IDE || ', ' || rec.CARGO_TRABAJO      || ', ' || rec.EMPLEADO           
        || ', ' || rec.CLIENTE              || ', ' || rec.NOM_IDENTIFICACION   || ', ' || rec.NOM_PAIS           || ', ' || rec.NOM_ESTADO_CIVIL    
        || ', ' || rec.RANGO                || ', ' || rec.NOM_MONEDA           || ', ' || rec.DIRECCION_SUC
        );
    END LOOP;
END;
/

--10 -N°49 -N°2
CREATE OR REPLACE PROCEDURE USP_ListadoPersonasEmpleadasCaidas(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.NOMBRE,
              A.APE_PATE,
              A.APE_MATE,
              A.FECHA_NAC,
              A.DIRECCION_RES,
              A.TEL_CEL,
              A.TEL_FIJO,
              A.CORREO_ELECTRONICO,
              A.SEXO,
              A.NUM_IDENTIFICACION,
              A.FECHA_EXPIRACION_IDE,
              A.CARGO_TRABAJO,
              A.EMPLEADO,
              
              B.CLIENTE,
              
              C.NOM_IDENTIFICACION,
              
              D.NOM_PAIS,
              
              E.NOM_ESTADO_CIVIL,
              
              F.RANGO,
              
              G.NOM_MONEDA,
              
              H.DIRECCION AS DIRECCION_SUC
              
        FROM  TB_PERSONAS A
        INNER JOIN TB_TIPO_CLIENTE        B ON A.ID_TP_CLIENTE     = B.ID_TP_CLIENTE
        INNER JOIN TB_TIPO_IDENTIFICACION C ON A.ID_IDENTIFICACION = C.ID_IDENTIFICACION
        INNER JOIN TB_PAISES              D ON A.ID_PAIS           = D.ID_PAIS
        INNER JOIN TB_ESTADOS_CIVILES     E ON A.ID_ESTADO_CIVIL   = E.ID_ESTADO_CIVIL
        INNER JOIN TB_RANGO_INGRESO       F ON A.ID_RANGO_INGRESO  = F.ID_RANGO_INGRESO
        INNER JOIN TB_MONEDAS             G ON A.ID_MONEDA         = G.ID_MONEDA
        INNER JOIN TB_SUCURSAL            H ON A.ID_SUCURSAL       = H.ID_SUCURSAL
        WHERE A.ESTADO = 0 AND A.EMPLEADO = 1
        AND   (
               A.NOMBRE               LIKE '%' || cTexto || '%' OR
               A.APE_PATE             LIKE '%' || cTexto || '%' OR
               A.APE_MATE             LIKE '%' || cTexto || '%' OR
               A.FECHA_NAC            LIKE '%' || cTexto || '%' OR
               A.DIRECCION_RES        LIKE '%' || cTexto || '%' OR
               A.TEL_CEL              LIKE '%' || cTexto || '%' OR
               A.TEL_FIJO             LIKE '%' || cTexto || '%' OR
               A.CORREO_ELECTRONICO   LIKE '%' || cTexto || '%' OR
               A.SEXO                 LIKE '%' || cTexto || '%' OR
               A.NUM_IDENTIFICACION   LIKE '%' || cTexto || '%' OR
               A.FECHA_EXPIRACION_IDE LIKE '%' || cTexto || '%' OR
               A.CARGO_TRABAJO        LIKE '%' || cTexto || '%' OR
               A.EMPLEADO             LIKE '%' || cTexto || '%' OR
               
               B.CLIENTE              LIKE '%' || cTexto || '%' OR
              
               C.NOM_IDENTIFICACION   LIKE '%' || cTexto || '%' OR
              
               D.NOM_PAIS             LIKE '%' || cTexto || '%' OR
              
               E.NOM_ESTADO_CIVIL     LIKE '%' || cTexto || '%' OR
              
               F.RANGO                LIKE '%' || cTexto || '%' OR
              
               G.NOM_MONEDA           LIKE '%' || cTexto || '%' OR
              
               H.CODIGO_SUCURSAL      LIKE '%' || cTexto || '%' OR
               H.DIRECCION            LIKE '%' || cTexto || '%'
              )
        ORDER BY A.ID_PERSONA DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION       || ', ' || rec.HORA_CREACION      || ', ' || rec.NOMBRE        
        || ', ' || rec.APE_PATE             || ', ' || rec.APE_MATE             || ', ' || rec.FECHA_NAC          || ', ' || rec.DIRECCION_RES 
        || ', ' || rec.TEL_CEL              || ', ' || rec.TEL_FIJO             || ', ' || rec.CORREO_ELECTRONICO || ', ' || rec.SEXO              
        || ', ' || rec.NUM_IDENTIFICACION   || ', ' || rec.FECHA_EXPIRACION_IDE || ', ' || rec.CARGO_TRABAJO      || ', ' || rec.EMPLEADO           
        || ', ' || rec.CLIENTE              || ', ' || rec.NOM_IDENTIFICACION   || ', ' || rec.NOM_PAIS           || ', ' || rec.NOM_ESTADO_CIVIL    
        || ', ' || rec.RANGO                || ', ' || rec.NOM_MONEDA           || ', ' || rec.DIRECCION_SUC
        );
    END LOOP;
END;
/


--10 -N°50 -N°1
create or replace NONEDITIONABLE PROCEDURE USP_GuardarPersonasCliente(
    nOpcion             NUMBER DEFAULT 0,
    nId_Persona         NUMBER DEFAULT 0,
    nId_TipoCliente     NUMBER DEFAULT 0,
    nId_Identificacion  NUMBER DEFAULT 0,
    nId_Pais            NUMBER DEFAULT 0,
    nId_EstadoCivil     NUMBER DEFAULT 0,
    nId_RangoIngreso    NUMBER DEFAULT 0,
    nId_Moneda          NUMBER DEFAULT 0,
    
    cNombre             VARCHAR2,
    cApePate            VARCHAR2,
    cApeMate            VARCHAR2,
    cFechaNac           DATE,
    cDireccionRes       VARCHAR2,
    cTelCel             VARCHAR2,
    cTelFijo            VARCHAR2,
    cCorreoElectronico  VARCHAR2,
    cSexo               FLOAT,
    cNumIdentificacion  VARCHAR2,
    cFechaExpiracionIDE DATE,
    cCargoTrabajo       VARCHAR2,
    cEmpleado           FLOAT
)
AS
    cFecha_Modificacion DATE DEFAULT SYSDATE;
    cModificado_Por     VARCHAR2(60) := NULL;
    xCodigo             NUMBER := 0;
    fFecha              DATE;
    empleado            varchar2(50) := NULL;
BEGIN
    SELECT 'X' INTO empleado FROM tb_usuario WHERE usuario = cModificado_Por;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        empleado := NULL;
        
    IF nOpcion = 1 THEN -- Nuevo Registro
            INSERT INTO TB_PERSONAS (
            ID_TP_CLIENTE,
            ID_IDENTIFICACION,
            ID_PAIS,
            ID_ESTADO_CIVIL,
            ID_RANGO_INGRESO,
            ID_MONEDA,
            
            NOMBRE,
            APE_PATE,
            APE_MATE,
            FECHA_NAC,
            DIRECCION_RES,
            TEL_CEL,
            TEL_FIJO,
            CORREO_ELECTRONICO,
            SEXO,
            NUM_IDENTIFICACION,
            FECHA_EXPIRACION_IDE,
            CARGO_TRABAJO,
            EMPLEADO,
            ESTADO
            )
            VALUES (
            nId_TipoCliente,
            nId_Identificacion,
            nId_Pais,
            nId_EstadoCivil,
            nId_RangoIngreso,
            nId_Moneda,
        
            cNombre,
            cApePate,
            cApeMate,
            cFechaNac,
            cDireccionRes,
            cTelCel,
            cTelFijo,
            cCorreoElectronico,
            cSexo,
            cNumIdentificacion,
            cFechaExpiracionIDE,
            cCargoTrabajo,
            0,
            1
            );
        --dbms_output.put_line(cTipo_Persona);
    ELSE  -- Actualizar registro
        UPDATE TB_PERSONAS
        SET
            ID_TP_CLIENTE       = nId_TipoCliente,
            ID_IDENTIFICACION   = nId_Identificacion,
            ID_PAIS             = nId_Pais,
            ID_ESTADO_CIVIL     = nId_EstadoCivil,
            ID_RANGO_INGRESO    = nId_RangoIngreso,
            ID_MONEDA           = nId_Moneda,
            
            NOMBRE               = cNombre,
            APE_PATE             = cApePate,
            APE_MATE             = cApeMate,
            FECHA_NAC            = cFechaNac,
            DIRECCION_RES        = cDireccionRes,
            TEL_CEL              = cTelCel,
            TEL_FIJO             = cTelFijo,
            CORREO_ELECTRONICO   = cCorreoElectronico,
            SEXO                 = cSexo,
            NUM_IDENTIFICACION   = cNumIdentificacion,
            FECHA_EXPIRACION_IDE = cFechaExpiracionIDE,
            CARGO_TRABAJO        = cCargoTrabajo,
            EMPLEADO             = cEmpleado,
            
            FECHA_MODIFICACION   = cFecha_Modificacion,
            MODIFICADO_POR       = cModificado_Por
        WHERE 
            ID_PERSONA = nId_Persona;
        --dbms_output.put_line('salida update');
end if;
commit;
END;
/

--10 -N°50 -N°2
create or replace NONEDITIONABLE PROCEDURE USP_GuardarPersonasEmpleadas(
    nOpcion             NUMBER DEFAULT 0,
    nId_Persona         NUMBER DEFAULT 0,
    nId_Identificacion  NUMBER DEFAULT 0,
    nId_Pais            NUMBER DEFAULT 0,
    nId_EstadoCivil     NUMBER DEFAULT 0,
    nId_RangoIngreso    NUMBER DEFAULT 0,
    nId_Moneda          NUMBER DEFAULT 0,
    nId_Sucursal        NUMBER DEFAULT 0,
    nId_Depto           NUMBER DEFAULT 0,
    
    cNombre             VARCHAR2,
    cApePate            VARCHAR2,
    cApeMate            VARCHAR2,
    cFechaNac           DATE,
    cDireccionRes       VARCHAR2,
    cTelCel             VARCHAR2,
    cTelFijo            VARCHAR2,
    cCorreoElectronico  VARCHAR2,
    cSexo               FLOAT,
    cNumIdentificacion  VARCHAR2,
    cFechaExpiracionIDE DATE,
    cEmpleado           FLOAT
)
AS
    cFecha_Modificacion DATE DEFAULT SYSDATE;
    cModificado_Por     VARCHAR2(60) := NULL;
    xCodigo             NUMBER := 0;
    fFecha              DATE;
    empleado            varchar2(50) := NULL;
BEGIN
    SELECT 'X' INTO empleado FROM tb_usuario WHERE usuario = cModificado_Por;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        empleado := NULL;
        
    IF nOpcion = 1 THEN -- Nuevo Registro
            INSERT INTO TB_PERSONAS (
            ID_TP_CLIENTE,
            ID_IDENTIFICACION,
            ID_PAIS,
            ID_ESTADO_CIVIL,
            ID_RANGO_INGRESO,
            ID_MONEDA,
            ID_SUCURSAL,
            ID_DEPTO,
            
            NOMBRE,
            APE_PATE,
            APE_MATE,
            FECHA_NAC,
            DIRECCION_RES,
            TEL_CEL,
            TEL_FIJO,
            CORREO_ELECTRONICO,
            SEXO,
            NUM_IDENTIFICACION,
            FECHA_EXPIRACION_IDE,
            CARGO_TRABAJO,
            EMPLEADO,
            ESTADO
            )
            VALUES (
            NULL,
            nId_Identificacion,
            nId_Pais,
            nId_EstadoCivil,
            nId_RangoIngreso,
            nId_Moneda,
            nId_Sucursal,
            nId_Depto,
        
            cNombre,
            cApePate,
            cApeMate,
            cFechaNac,
            cDireccionRes,
            cTelCel,
            cTelFijo,
            cCorreoElectronico,
            cSexo,
            cNumIdentificacion,
            cFechaExpiracionIDE,
            NULL,
            1,
            1
            );
        --dbms_output.put_line(cTipo_Persona);
    ELSE  -- Actualizar registro
        UPDATE TB_PERSONAS
        SET
            ID_IDENTIFICACION   = nId_Identificacion,
            ID_PAIS             = nId_Pais,
            ID_ESTADO_CIVIL     = nId_EstadoCivil,
            ID_RANGO_INGRESO    = nId_RangoIngreso,
            ID_MONEDA           = nId_Moneda,
            ID_SUCURSAL         = nId_Sucursal,
            ID_DEPTO            = nId_Depto,
            
            NOMBRE               = cNombre,
            APE_PATE             = cApePate,
            APE_MATE             = cApeMate,
            FECHA_NAC            = cFechaNac,
            DIRECCION_RES        = cDireccionRes,
            TEL_CEL              = cTelCel,
            TEL_FIJO             = cTelFijo,
            CORREO_ELECTRONICO   = cCorreoElectronico,
            SEXO                 = cSexo,
            NUM_IDENTIFICACION   = cNumIdentificacion,
            FECHA_EXPIRACION_IDE = cFechaExpiracionIDE,
            EMPLEADO             = cEmpleado,
            
            FECHA_MODIFICACION   = cFecha_Modificacion,
            MODIFICADO_POR       = cModificado_Por
        WHERE 
            ID_PERSONA = nId_Persona;
        --dbms_output.put_line('salida update');
end if;
commit;
END;
/

--10 -N°51 -N°1
CREATE OR REPLACE PROCEDURE USP_EliminarPersonasClientes(
    nId_Persona IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_PERSONAS
    SET ESTADO = 0
    WHERE ID_PERSONA = nId_Persona
    AND   EMPLEADO = 0;
END;
/

--10 -N°52 -N°2
CREATE OR REPLACE PROCEDURE USP_EliminarPersonasEmpleadas(
    nId_Persona IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_PERSONAS
    SET ESTADO = 0
    WHERE ID_PERSONA = nId_Persona
    AND   EMPLEADO = 1;
END;
/

--10 -N°53 -N°1
CREATE OR REPLACE PROCEDURE USP_LevantarPersonasClientes(
    nId_Persona IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_PERSONAS
    SET ESTADO = 1
    WHERE ID_PERSONA = nId_Persona
    AND   EMPLEADO = 0;
END;
/

--10 -N°54 -N°2
CREATE OR REPLACE PROCEDURE USP_LevantarPersonasEmpleadas(
    nId_Persona IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_PERSONAS
    SET ESTADO = 1
    WHERE ID_PERSONA = nId_Persona
    AND   EMPLEADO = 1;
END;
/
--TERMINADO

-----------------------------------------------------
/* PROCEDIMIENTOS ALMACENADOS DE TB_USUARIO */
--11 -N°55
CREATE OR REPLACE PROCEDURE USP_ListadoUsuarios(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.USUARIO,
              A.CONTRASEÑA,
              A.ADMINISTRADOR,
              A.PRESTAMOS,
              A.CUENTAS,
              A.TARJETAS,
              
              B.CODIGO_SUCURSAL,
              B.DIRECCION,
              
              C.NOM_CARGO,
              
              D.NOMBRE,
              D.APE_PATE,
              D.APE_MATE
              
        FROM  TB_USUARIO A
        INNER JOIN TB_SUCURSAL            B ON A.ID_SUCURSAL       = B.ID_SUCURSAL
        INNER JOIN TB_CARGO_EMPLEADO      C ON A.ID_CARGO_EMPLEADO = C.ID_CARGO_EMPLEADO
        INNER JOIN TB_PERSONAS            D ON A.ID_PERSONA        = D.ID_PERSONA
        WHERE A.ESTADO = 1
        AND   (
               A.USUARIO              LIKE '%' || cTexto || '%' OR
               
               B.CODIGO_SUCURSAL      LIKE '%' || cTexto || '%' OR
               B.DIRECCION            LIKE '%' || cTexto || '%' OR
              
               C.NOM_CARGO            LIKE '%' || cTexto || '%' OR
              
               D.NOMBRE               LIKE '%' || cTexto || '%' OR
               D.APE_PATE             LIKE '%' || cTexto || '%' OR
               D.APE_MATE             LIKE '%' || cTexto || '%'
              )
        ORDER BY A.ID_USER DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION       || ', ' || rec.HORA_CREACION      || ', ' || rec.USUARIO        
        || ', ' || rec.CONTRASEÑA           || ', ' || rec.CODIGO_SUCURSAL      || ', ' || rec.DIRECCION          || ', ' || rec.NOM_CARGO 
        || ', ' || rec.NOMBRE               || ', ' || rec.APE_PATE             || ', ' || rec.APE_MATE           
        );
    END LOOP;
END;
/

--11 -N°56
CREATE OR REPLACE PROCEDURE USP_ListadoUsuariosCaidos(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.USUARIO,
              A.CONTRASEÑA,
              A.ADMINISTRADOR,
              A.PRESTAMOS,
              A.CUENTAS,
              A.TARJETAS,
              
              B.CODIGO_SUCURSAL,
              B.DIRECCION,
              
              C.NOM_CARGO,
              
              D.NOMBRE,
              D.APE_PATE,
              D.APE_MATE
              
        FROM  TB_USUARIO A
        INNER JOIN TB_SUCURSAL            B ON A.ID_SUCURSAL       = B.ID_SUCURSAL
        INNER JOIN TB_CARGO_EMPLEADO      C ON A.ID_CARGO_EMPLEADO = C.ID_CARGO_EMPLEADO
        INNER JOIN TB_PERSONAS            D ON A.ID_PERSONA        = D.ID_PERSONA
        WHERE A.ESTADO = 0
        AND   (
               A.USUARIO              LIKE '%' || cTexto || '%' OR
               
               B.CODIGO_SUCURSAL      LIKE '%' || cTexto || '%' OR
               B.DIRECCION            LIKE '%' || cTexto || '%' OR
              
               C.NOM_CARGO            LIKE '%' || cTexto || '%' OR
              
               D.NOMBRE               LIKE '%' || cTexto || '%' OR
               D.APE_PATE             LIKE '%' || cTexto || '%' OR
               D.APE_MATE             LIKE '%' || cTexto || '%'
              )
        ORDER BY A.ID_USER DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION       || ', ' || rec.HORA_CREACION      || ', ' || rec.USUARIO        
        || ', ' || rec.CONTRASEÑA           || ', ' || rec.CODIGO_SUCURSAL      || ', ' || rec.DIRECCION          || ', ' || rec.NOM_CARGO 
        || ', ' || rec.NOMBRE               || ', ' || rec.APE_PATE             || ', ' || rec.APE_MATE           
        );
    END LOOP;
END;
/

--SELECT*FROM TB_SUCURSAL;
--SELECT*FROM TB_CARGO_EMPLEADO;
--SELECT*FROM TB_PERSONAS;
--SELECT*FROM TB_USUARIO;

--11 -N°57
create or replace NONEDITIONABLE PROCEDURE USP_GuardarUsuario(
    nOpcion             IN NUMBER DEFAULT 0,
    nId_User            IN NUMBER DEFAULT 0,
    nId_Sucursal        IN NUMBER DEFAULT 0,
    nId_CargoEmpleado   IN NUMBER DEFAULT 0,
    nId_Persona         IN NUMBER DEFAULT 0,
    
    cUsuario            IN VARCHAR2,
    cContraseña         IN VARCHAR2,
    
    cAdministrador      IN NUMBER,
    cPrestamos          IN NUMBER,
    cCuentas            IN NUMBER,
    cTarjetas           IN NUMBER
)
AS
    cFecha_Modificacion DATE DEFAULT SYSDATE;
    cModificado_Por     VARCHAR2(60) := NULL;
    xCodigo  INT := 0;
    fFecha   DATE;
    empleado varchar2(50) := NULL;
BEGIN
    SELECT 'X' INTO empleado FROM tb_usuario WHERE usuario = cModificado_Por;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        empleado := NULL; --ACA SE NECECITA ALMACENAR EL USUARIO DE LA APLICACION


    IF nOpcion = 1 THEN -- Nuevo Registro
        INSERT 
        INTO 
        TB_USUARIO(
                  ID_SUCURSAL,
                  ID_CARGO_EMPLEADO,
                  ID_PERSONA,
                  
                  USUARIO,
                  CONTRASEÑA,
                  ADMINISTRADOR,
                  PRESTAMOS,
                  CUENTAS,
                  TARJETAS,
                  ESTADO
                )
        VALUES   (
                  nId_Sucursal,
                  nId_CargoEmpleado,
                  nId_Persona,
                  
                  cUsuario,
                  cContraseña,
                  cAdministrador,
                  cPrestamos,
                  cCuentas,
                  cTarjetas,
                  1
                );
        --dbms_output.put_line('salida insert');
    ELSE -- Actualizar registro
        UPDATE TB_USUARIO
        SET
            ID_SUCURSAL          = nId_Sucursal,
            ID_CARGO_EMPLEADO    = nId_CargoEmpleado,
            ID_PERSONA           = nId_Persona,
            
            USUARIO              = cUsuario,
            CONTRASEÑA           = cContraseña,
            ADMINISTRADOR        = cAdministrador,
            PRESTAMOS            = cPrestamos,
            CUENTAS              = cCuentas,
            TARJETAS             = cTarjetas,
            
            FECHA_MODIFICACION   = cFecha_Modificacion,
            MODIFICADO_POR       = cModificado_Por
        WHERE
            ID_USER              = nId_User;
        --dbms_output.put_line('salida update');
end if;
commit;
END;
/

--11 -N°58
CREATE OR REPLACE PROCEDURE USP_EliminarUsuario(
    nId_User IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_USUARIO
    SET ESTADO = 0
    WHERE ID_USER = nId_User;
END;
/

--11 -N°59
CREATE OR REPLACE PROCEDURE USP_LevantarUsuario(
    nId_User IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_USUARIO
    SET ESTADO = 1
    WHERE ID_USER = nId_User;
END;
/
--TERMINADO

-----------------------------------------------------
/* PROCEDIMIENTOS ALMACENADOS DE TB_TIPO_PRODUCTO */
--12 -N°60
CREATE OR REPLACE PROCEDURE USP_ListadoTipoProducto(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              FECHA_CREACION,
              HORA_CREACION,
              NOM_SERVICIO
              
        FROM  TB_TIPO_PRODUCTO
        WHERE ESTADO = 1
        AND   NOM_SERVICIO    LIKE '%' || cTexto || '%'
        ORDER BY ID_TIPO_PRODUCTO DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION       || ', ' || rec.HORA_CREACION      || ', ' || rec.NOM_SERVICIO
        );
    END LOOP;
END;
/

--12 -N°61
CREATE OR REPLACE PROCEDURE USP_ListadoTipoProductoCaido(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              FECHA_CREACION,
              HORA_CREACION,
              NOM_SERVICIO
              
        FROM  TB_TIPO_PRODUCTO
        WHERE ESTADO = 0
        AND   NOM_SERVICIO    LIKE '%' || cTexto || '%'
        ORDER BY ID_TIPO_PRODUCTO DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION       || ', ' || rec.HORA_CREACION      || ', ' || rec.NOM_SERVICIO
        );
    END LOOP;
END;
/

--12 -N°62
create or replace NONEDITIONABLE PROCEDURE USP_GuardarTipoProducto(
    nOpcion             IN NUMBER DEFAULT 0,
    nId_TipoProducto    IN NUMBER DEFAULT 0,    
    cNomServicio        IN VARCHAR2
)
AS
    cFecha_Modificacion DATE DEFAULT SYSDATE;
    cModificado_Por     VARCHAR2(60) := NULL;
    xCodigo INT := 0;
    fFecha  DATE;
    empleado varchar2(50) := NULL;
BEGIN
    SELECT 'X' INTO empleado FROM tb_usuario WHERE usuario = cModificado_Por;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        empleado := NULL;


    IF nOpcion = 1 THEN -- Nuevo Registro
        INSERT 
        INTO 
        TB_TIPO_PRODUCTO(
                  NOM_SERVICIO,
                  ESTADO
                )
        VALUES   (
                  cNomServicio,                  
                  1
                );
        --dbms_output.put_line('salida insert');
    ELSE -- Actualizar registro
        UPDATE TB_TIPO_PRODUCTO
        SET            
            NOM_SERVICIO         = cNomServicio, 
            FECHA_MODIFICACION   = cFecha_Modificacion,
            MODIFICADO_POR       = cModificado_Por
        WHERE
            ID_TIPO_PRODUCTO     = nId_TipoProducto;
        --dbms_output.put_line('salida update');
end if;
commit;
END;
/

--12 -N°63
CREATE OR REPLACE PROCEDURE USP_EliminarTipoProducto(
    nId_TipoProducto IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_TIPO_PRODUCTO
    SET    ESTADO = 0
    WHERE  ID_TIPO_PRODUCTO = nId_TipoProducto;
END;
/

--12 -N°64
CREATE OR REPLACE PROCEDURE USP_LevantarTipoProducto(
    nId_TipoProducto IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_TIPO_PRODUCTO
    SET    ESTADO = 1
    WHERE  ID_TIPO_PRODUCTO = nId_TipoProducto;
END;
/
--TERMINADO

-----------------------------------------------------
/* PROCEDIMIENTOS ALMACENADOS DE TB_PRODUCTO_APLICACION */
--13 -N°65
CREATE OR REPLACE PROCEDURE USP_ListadoProductoAplicacion(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.NOM_CUENTA,
              B.NOM_SERVICIO,
              C.NOM_MONEDA
              
        FROM  TB_PRODUCTO_APLICACION A
        INNER JOIN TB_TIPO_PRODUCTO  B ON A.ID_TIPO_PRODUCTO  = B.ID_TIPO_PRODUCTO
        INNER JOIN TB_MONEDAS        C ON A.ID_MONEDA         = C.ID_MONEDA
        WHERE A.ESTADO = 1
        AND   A.NOM_CUENTA    LIKE '%' || cTexto || '%'
        ORDER BY A.ID_TIPO_APLICACION DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION       || ', ' || rec.HORA_CREACION      || ', ' || rec.NOM_CUENTA
        || ', ' || rec.NOM_SERVICIO || ', ' || rec.NOM_MONEDA
        );
    END LOOP;
END;
/

--13 -N°66
CREATE OR REPLACE PROCEDURE USP_ListadoProductoAplicacionCaido(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.NOM_CUENTA,
              B.NOM_SERVICIO,
              C.NOM_MONEDA
              
        FROM  TB_PRODUCTO_APLICACION A
        INNER JOIN TB_TIPO_PRODUCTO  B ON A.ID_TIPO_PRODUCTO  = B.ID_TIPO_PRODUCTO
        INNER JOIN TB_MONEDAS        C ON A.ID_MONEDA         = C.ID_MONEDA
        WHERE A.ESTADO = 0
        AND   A.NOM_CUENTA    LIKE '%' || cTexto || '%'
        ORDER BY A.ID_TIPO_APLICACION DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION       || ', ' || rec.HORA_CREACION      || ', ' || rec.NOM_CUENTA
        || ', ' || rec.NOM_SERVICIO || ', ' || rec.NOM_MONEDA
        );
    END LOOP;
END;
/

--13 -N°67
create or replace NONEDITIONABLE PROCEDURE USP_GuardarProductoAplicacion(
    nOpcion             IN NUMBER DEFAULT 0,
    nId_TipoAplicacion  IN NUMBER DEFAULT 0,
    nId_TipoProducto    IN NUMBER DEFAULT 0,
    nId_Moneda          IN NUMBER DEFAULT 0,    
    cNomProducto        IN VARCHAR2
)
AS
    cFecha_Modificacion DATE DEFAULT SYSDATE;
    cModificado_Por     VARCHAR2(60) := NULL;
    xCodigo INT := 0;
    fFecha  DATE;
    empleado varchar2(50) := NULL;
BEGIN
    SELECT 'X' INTO empleado FROM tb_usuario WHERE usuario = cModificado_Por;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        empleado := NULL;


    IF nOpcion = 1 THEN -- Nuevo Registro
        INSERT 
        INTO 
        TB_PRODUCTO_APLICACION(
                  ID_TIPO_PRODUCTO,
                  ID_MONEDA,
                  NOM_PRODUCTO,
                  ESTADO
                )
        VALUES   (
                  nId_TipoProducto,
                  nId_Moneda,
                  cNomProducto,                  
                  1
                );
        --dbms_output.put_line('salida insert');
    ELSE -- Actualizar registro
        UPDATE TB_PRODUCTO_APLICACION
        SET
            ID_TIPO_PRODUCTO     = nId_TipoProducto,
            ID_MONEDA            = nId_Moneda,
            NOM_PRODUCTO         = cNomProducto,
            FECHA_MODIFICACION   = cFecha_Modificacion,
            MODIFICADO_POR       = cModificado_Por
        WHERE
            ID_TIPO_APLICACION   = nId_TipoAplicacion;
        --dbms_output.put_line('salida update');
end if;
commit;
END;
/

--13 -N°68
CREATE OR REPLACE PROCEDURE USP_EliminarProductoAplicacion(
    nId_TipoAplicacion IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_PRODUCTO_APLICACION
    SET    ESTADO = 0
    WHERE  ID_TIPO_APLICACION = nId_TipoAplicacion;
END;
/

--13 -N°69
CREATE OR REPLACE PROCEDURE USP_LevantarProductoAplicacion(
    nId_TipoAplicacion IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_PRODUCTO_APLICACION
    SET    ESTADO = 1
    WHERE  ID_TIPO_APLICACION = nId_TipoAplicacion;
END;
/
--TERMINADO

-----------------------------------------------------
/* PROCEDIMIENTOS ALMACENADOS DE TB_CUENTA */
--14 -N°70
CREATE OR REPLACE PROCEDURE USP_ListadoCuentas(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.CODIGO_CUENTA,
              A.SALDO_APERTURA,
              A.SALDO_CUENTA,
              A.SALDO_CONGELADO,
              A.FECHA_CANCELACION,
              
              B.NOM_CUENTA,
              
              C.NOMBRE,
              C.APE_PATE,
              C.APE_MATE,
              
              D.DIRECCION
              
        FROM  TB_CUENTA A
        INNER JOIN TB_PRODUCTO_APLICACION B ON A.ID_TIPO_APLICACION = B.ID_TIPO_APLICACION
        INNER JOIN TB_PERSONAS            C ON A.ID_PERSONA         = C.ID_PERSONA
        INNER JOIN TB_SUCURSAL            D ON A.ID_SUCURSAL        = D.ID_SUCURSAL
        WHERE A.ESTADO = 1
        AND  (
              A.CODIGO_CUENTA LIKE '%' || cTexto || '%' OR
              C.NOMBRE        LIKE '%' || cTexto || '%' OR
              C.APE_PATE      LIKE '%' || cTexto || '%' OR
              C.APE_MATE      LIKE '%' || cTexto || '%'
              )
        ORDER BY A.ID_CUENTA DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION  || ', ' || rec.HORA_CREACION     || ', ' || rec.CODIGO_CUENTA
        || ', ' || rec.SALDO_APERTURA      || ', ' || rec.SALDO_CONGELADO || ', ' || rec.FECHA_CANCELACION || ', ' || rec.NOM_CUENTA
        || ', ' || rec.NOMBRE || ', ' || rec.APE_PATE || ', ' || rec.APE_MATE || ', ' || rec.DIRECCION
        );
    END LOOP;
END;
/

--14 -N°71
CREATE OR REPLACE PROCEDURE USP_ListadoCuentasCaidas(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.CODIGO_CUENTA,
              A.SALDO_APERTURA,
              A.SALDO_CUENTA,
              A.SALDO_CONGELADO,
              A.FECHA_CANCELACION,
              
              B.NOM_CUENTA,
              
              C.NOMBRE,
              C.APE_PATE,
              C.APE_MATE,
              
              D.DIRECCION
              
        FROM  TB_CUENTA A
        INNER JOIN TB_PRODUCTO_APLICACION B ON A.ID_TIPO_APLICACION = B.ID_TIPO_APLICACION
        INNER JOIN TB_PERSONAS            C ON A.ID_PERSONA         = C.ID_PERSONA
        INNER JOIN TB_SUCURSAL            D ON A.ID_SUCURSAL        = D.ID_SUCURSAL
        WHERE A.ESTADO = 0
        AND  (
              A.CODIGO_CUENTA LIKE '%' || cTexto || '%' OR
              C.NOMBRE        LIKE '%' || cTexto || '%' OR
              C.APE_PATE      LIKE '%' || cTexto || '%' OR
              C.APE_MATE      LIKE '%' || cTexto || '%'
              )
        ORDER BY A.ID_CUENTA DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION  || ', ' || rec.HORA_CREACION     || ', ' || rec.CODIGO_CUENTA
        || ', ' || rec.SALDO_APERTURA      || ', ' || rec.SALDO_CONGELADO || ', ' || rec.FECHA_CANCELACION || ', ' || rec.NOM_CUENTA
        || ', ' || rec.NOMBRE || ', ' || rec.APE_PATE || ', ' || rec.APE_MATE || ', ' || rec.DIRECCION
        );
    END LOOP;
END;
/

--14 -N°72
CREATE OR REPLACE NONEDITIONABLE PROCEDURE USP_GuardarCuenta(
    nOpcion             IN NUMBER DEFAULT 0,
    nId_Cuenta          IN NUMBER DEFAULT 0,
    nId_TipoAplicacion  IN NUMBER DEFAULT 0,
    nId_Persona         IN NUMBER DEFAULT 0,
    nId_Sucursal        IN NUMBER DEFAULT 0,
    cSaldoCuenta        IN NUMBER
)
AS
    cFechaCancelacion   DATE;
    cCodigoCuenta       VARCHAR2(12);
    cSaldoCongelado     NUMBER(18,2) DEFAULT 0.00;
    cSaldoApertura      NUMBER(18,2) DEFAULT 0.00;
    cFecha_Modificacion DATE DEFAULT SYSDATE;
    cModificado_Por     VARCHAR2(50) := NULL;
    bPrimerRegistro     BOOLEAN := TRUE;
BEGIN
    -- Insertar o actualizar según nOpcion
    IF nOpcion = 1 THEN -- Nuevo Registro
        IF bPrimerRegistro THEN
            cSaldoApertura := cSaldoCuenta; -- Solo asignar aquí para el primer registro
            bPrimerRegistro := FALSE; -- Marcar que el primer registro ha sido insertado
        END IF;
        
        INSERT INTO TB_CUENTA(
                  ID_TIPO_APLICACION,
                  ID_PERSONA,
                  ID_SUCURSAL,
                  SALDO_APERTURA,
                  SALDO_CUENTA,
                  ESTADO
                )
        VALUES (
                  nId_TipoAplicacion,
                  nId_Persona,
                  nId_Sucursal,
                  cSaldoApertura,
                  cSaldoCuenta,
                  1
                );
    ELSE -- Actualizar registro
        UPDATE TB_CUENTA
        SET
            ID_TIPO_APLICACION   = nId_TipoAplicacion,
            ID_PERSONA           = nId_Persona,
            ID_SUCURSAL          = nId_Sucursal,
            CODIGO_CUENTA        = cCodigoCuenta,
            -- SALDO_APERTURA no se actualiza aquí
            SALDO_CUENTA         = cSaldoCuenta,
            SALDO_CONGELADO      = cSaldoCongelado,
            FECHA_CANCELACION    = cFechaCancelacion,
            FECHA_MODIFICACION   = cFecha_Modificacion,
            MODIFICADO_POR       = cModificado_Por
        WHERE
            ID_CUENTA            = nId_Cuenta;
    END IF;
    COMMIT;
END;


--14 -N°73
CREATE OR REPLACE PROCEDURE USP_EliminarCuenta(
    nId_Cuenta IN NUMBER DEFAULT 0
)
AS
cFechaCancelacion   DATE DEFAULT SYSDATE;
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_CUENTA
    SET    ESTADO = 0
    WHERE  ID_CUENTA = nId_Cuenta;
    UPDATE TB_CUENTA
    SET
        FECHA_CANCELACION = cFechaCancelacion
    WHERE
        ID_CUENTA = nId_Cuenta;
END;
/

--14 -N°74
CREATE OR REPLACE PROCEDURE USP_LevantarCuenta(
    nId_Cuenta IN NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_CUENTA
    SET    ESTADO = 1
    WHERE  ID_CUENTA = nId_Cuenta;
END;
/
--TERMINADO

-----------------------------------------------------
/* PROCEDIMIENTOS ALMACENADOS DE TB_TIPO_TARJETA */
--15 -N°75
CREATE OR REPLACE PROCEDURE USP_ListadoTipoTarjeta(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              FECHA_CREACION,
              HORA_CREACION,
              NOM_TARJETA
              
        FROM  TB_TIPO_TARJETA
        WHERE ESTADO = 1
        AND   NOM_TARJETA         LIKE '%' || cTexto || '%'
        ORDER BY NOM_TARJETA DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION  || ', ' || rec.HORA_CREACION     || ', ' || rec.NOM_TARJETA
        );
    END LOOP;
END;
/

--15 -N°76
CREATE OR REPLACE PROCEDURE USP_ListadoTipoTarjetasCaidas(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              FECHA_CREACION,
              HORA_CREACION,
              NOM_TARJETA
              
        FROM  TB_TIPO_TARJETA
        WHERE ESTADO = 0
        AND   NOM_TARJETA         LIKE '%' || cTexto || '%'
        ORDER BY NOM_TARJETA DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION  || ', ' || rec.HORA_CREACION     || ', ' || rec.NOM_TARJETA
        );
    END LOOP;
END;
/

--15 -N°77
create or replace NONEDITIONABLE PROCEDURE USP_GuardarTipoTarjeta(
    nOpcion             NUMBER DEFAULT 0,
    nId_TipoTarjeta     NUMBER DEFAULT 0,
    cNomTarjeta         VARCHAR2
)
AS
    cFecha_Modificacion DATE DEFAULT SYSDATE;
    cModificado_Por     VARCHAR2(60) := NULL;
    xCodigo             NUMBER := 0;
    fFecha              DATE;
    empleado            varchar2(50) := NULL;
BEGIN
    SELECT 'X' INTO empleado FROM tb_usuario WHERE usuario = cModificado_Por;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        empleado := NULL;
        
    IF nOpcion = 1 THEN -- Nuevo Registro
        INSERT INTO TB_TIPO_TARJETA(
        NOM_TARJETA,
        ESTADO
        )
        VALUES (
        cNomTarjeta,
        1
        );
        --dbms_output.put_line(cTipo_Persona);
    ELSE  -- Actualizar registro
        UPDATE TB_TIPO_TARJETA
        SET
            NOM_TARJETA = cNomTarjeta,
            FECHA_MODIFICACION = cFecha_Modificacion,
            MODIFICADO_POR = cModificado_Por
        WHERE 
            ID_TIPO_TARJETA = nId_TipoTarjeta;
        --dbms_output.put_line('salida update');
end if;
commit;
END;
/

--15 -N°78
CREATE OR REPLACE PROCEDURE USP_EliminarTipoTarjeta(
    nId_TipoTarjeta NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_TIPO_TARJETA
    SET    ESTADO = 0
    WHERE  ID_TIPO_TARJETA = nId_TipoTarjeta;
END;
/

--15 -N°79
CREATE OR REPLACE PROCEDURE USP_LevantarTipoTarjeta(
    nId_TipoTarjeta NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_TIPO_TARJETA
    SET    ESTADO = 1
    WHERE  ID_TIPO_TARJETA = nId_TipoTarjeta;
END;
/
--TERMINADO

-----------------------------------------------------
/* PROCEDIMIENTOS ALMACENADOS DE TB_TARJETA */
--16 -N°80
CREATE OR REPLACE PROCEDURE USP_ListadoTarjeta(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.CODIGO_TARJETA,
              A.SALDO,
              A.LIMITE,
              B.NOMBRE,
              B.APE_PATE,
              B.APE_MATE,
              C.CODIGO_CUENTA,
              D.NOM_TARJETA
              
        FROM  TB_TARJETA A
        
        INNER JOIN TB_PERSONAS     B ON A.ID_PERSONA      = B.ID_PERSONA
        INNER JOIN TB_CUENTA       C ON A.ID_CUENTA       = C.ID_CUENTA
        INNER JOIN TB_TIPO_TARJETA D ON A.ID_TIPO_TARJETA = D.ID_TIPO_TARJETA
        
        WHERE A.ESTADO = 1
        AND  (
              A.CODIGO_TARJETA      LIKE '%' || cTexto || '%' OR
              A.SALDO               LIKE '%' || cTexto || '%' OR
              B.NOMBRE              LIKE '%' || cTexto || '%' OR
              B.APE_PATE            LIKE '%' || cTexto || '%' OR
              B.APE_MATE            LIKE '%' || cTexto || '%' OR
              C.CODIGO_CUENTA       LIKE '%' || cTexto || '%' OR
              D.NOM_TARJETA         LIKE '%' || cTexto || '%'
              )
        ORDER BY A.ID_TARJETA DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION  || ', ' || rec.HORA_CREACION     || ', ' || rec.CODIGO_TARJETA
        || ', ' || rec.SALDO || ', ' || rec.LIMITE || ', ' || rec.NOMBRE || ', ' || rec.APE_PATE || ', ' || rec.APE_MATE 
        || ', ' || rec.CODIGO_CUENTA || ', ' || rec.NOM_TARJETA
        );
    END LOOP;
END;
/

--16 -N°81
CREATE OR REPLACE PROCEDURE USP_ListadoTarjetasCaidas(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.CODIGO_TARJETA,
              A.SALDO,
              A.LIMITE,
              B.NOMBRE,
              B.APE_PATE,
              B.APE_MATE,
              C.CODIGO_CUENTA,
              D.NOM_TARJETA
              
        FROM  TB_TARJETA A
        
        INNER JOIN TB_PERSONAS     B ON A.ID_PERSONA      = B.ID_PERSONA
        INNER JOIN TB_CUENTA       C ON A.ID_CUENTA       = C.ID_CUENTA
        INNER JOIN TB_TIPO_TARJETA D ON A.ID_TIPO_TARJETA = D.ID_TIPO_TARJETA
        
        WHERE A.ESTADO = 0
        AND  (
              A.CODIGO_TARJETA      LIKE '%' || cTexto || '%' OR
              A.SALDO               LIKE '%' || cTexto || '%' OR
              B.NOMBRE              LIKE '%' || cTexto || '%' OR
              B.APE_PATE            LIKE '%' || cTexto || '%' OR
              B.APE_MATE            LIKE '%' || cTexto || '%' OR
              C.CODIGO_CUENTA       LIKE '%' || cTexto || '%' OR
              D.NOM_TARJETA         LIKE '%' || cTexto || '%'
              )
        ORDER BY A.ID_TARJETA DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(rec.FECHA_CREACION  || ', ' || rec.HORA_CREACION     || ', ' || rec.CODIGO_TARJETA
        || ', ' || rec.SALDO || ', ' || rec.LIMITE || ', ' || rec.NOMBRE || ', ' || rec.APE_PATE || ', ' || rec.APE_MATE 
        || ', ' || rec.CODIGO_CUENTA || ', ' || rec.NOM_TARJETA
        );
    END LOOP;
END;
/

--16 -N°82
create or replace NONEDITIONABLE PROCEDURE USP_GuardarTarjeta(
    nOpcion             NUMBER DEFAULT 0,
    nId_Tarjeta         NUMBER DEFAULT 0,
    nId_Persona         NUMBER DEFAULT 0,
    nId_Cuenta          NUMBER DEFAULT 0,
    nId_TipoTarjeta     NUMBER DEFAULT 0,
    cSaldo              NUMBER DEFAULT 00.00,
    cLimite             NUMBER DEFAULT 00.00
)
AS
    cFecha_Modificacion DATE DEFAULT SYSDATE;
    cModificado_Por     VARCHAR2(60) := NULL;
    xCodigo INT := 0;
    fFecha  DATE;
    empleado varchar2(50) := NULL;
BEGIN
    SELECT 'X' INTO empleado FROM tb_usuario WHERE usuario = cModificado_Por;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        empleado := NULL;


    IF nOpcion = 1 THEN -- Nuevo Registro
        INSERT 
        INTO 
        TB_TARJETA(
                  ID_PERSONA,
                  ID_CUENTA,
                  ID_TIPO_TARJETA,
                  SALDO,
                  LIMITE,
                  ESTADO
                )
        VALUES   (
                  nId_Persona,
                  nId_Cuenta,
                  nId_TipoTarjeta,
                  cSaldo,
                  cLimite,
                  1
                );
        --dbms_output.put_line('salida insert');
    ELSE -- Actualizar registro
        UPDATE TB_TARJETA
        SET
            ID_TARJETA           = nId_Tarjeta,
            SALDO                = cSaldo,
            LIMITE               = cLimite,
            FECHA_MODIFICACION   = cFecha_Modificacion,
            MODIFICADO_POR       = cModificado_Por
        WHERE
            ID_TARJETA           = nId_Tarjeta;
        --dbms_output.put_line('salida update');
end if;
commit;
END;
/

--16 -N°83
CREATE OR REPLACE PROCEDURE USP_EliminarTarjeta(
    nId_Tarjeta NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_TARJETA
    SET    ESTADO = 0
    WHERE  ID_TARJETA = nId_Tarjeta;
END;
/

--16 -N°84
CREATE OR REPLACE PROCEDURE USP_LevantarTarjeta(
    nId_Tarjeta NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_TARJETA
    SET    ESTADO = 1
    WHERE  ID_TARJETA = nId_Tarjeta;
END;
/
--TERMINADO

-----------------------------------------------------
/* PROCEDIMIENTOS ALMACENADOS DE TB_PRESTAMO */
--17 -N°85
CREATE OR REPLACE PROCEDURE USP_ListadoPrestamo(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.MONTO_OTORGADO,
              A.TASA_INTERES,
              A.PLAZO,
              A.TASA_EFECTIVA,
              A.CUOTA,
              A.FECHA_VENCIMIENTO,
              A.FRECUENCIA_PAGO,
              A.SALDO_INTERES,
              A.SALDO_CAPITAL,
              A.DIAS_ATRASO,
              A.SALDO_MORA,
              A.CODIGO_PRESTAMO,
              B.NOMBRE,
              C.CODIGO_CUENTA,
              D.NOM_CUENTA
              
        FROM  TB_PRESTAMO A
        
        INNER JOIN TB_PERSONAS            B ON A.ID_PERSONA         = B.ID_PERSONA
        INNER JOIN TB_CUENTA              C ON A.ID_CUENTA          = C.ID_CUENTA
        INNER JOIN TB_PRODUCTO_APLICACION D ON A.ID_TIPO_APLICACION = D.ID_TIPO_APLICACION
        
        WHERE A.ESTADO = 1
        AND  (
              A.CODIGO_PRESTAMO     LIKE '%' || cTexto || '%' OR
              B.NOMBRE              LIKE '%' || cTexto || '%' OR
              B.APE_PATE            LIKE '%' || cTexto || '%' OR
              B.APE_MATE            LIKE '%' || cTexto || '%' OR
              C.CODIGO_CUENTA       LIKE '%' || cTexto || '%' 
              )
        ORDER BY A.ID_PRESTAMO DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(
        rec.FECHA_CREACION  || ', ' || rec.HORA_CREACION     || ', ' || rec.MONTO_OTORGADO  || ', ' || 
        rec.TASA_INTERES    || ', ' || rec.PLAZO             || ', ' || rec.TASA_EFECTIVA   || ', ' || 
        rec.CUOTA           || ', ' || rec.FECHA_VENCIMIENTO || ', ' || rec.FRECUENCIA_PAGO || ', ' || 
        rec.SALDO_INTERES   || ', ' || rec.SALDO_CAPITAL     || ', ' || rec.DIAS_ATRASO     || ', ' || 
        rec.SALDO_MORA      || ', ' || rec.NOMBRE            || ', ' || rec.APE_PATE        || ', ' || 
        rec.APE_MATE          || ', ' || rec.CODIGO_CUENTA   || ', ' || rec.NOM_CUENTA
        );
    END LOOP;
END;
/

--17 -N°86
CREATE OR REPLACE PROCEDURE USP_ListadoPrestamosCaidos(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.MONTO_OTORGADO,
              A.TASA_INTERES,
              A.PLAZO,
              A.TASA_EFECTIVA,
              A.CUOTA,
              A.FECHA_VENCIMIENTO,
              A.FRECUENCIA_PAGO,
              A.SALDO_INTERES,
              A.SALDO_CAPITAL,
              A.DIAS_ATRASO,
              A.SALDO_MORA,
              A.CODIGO_PRESTAMO,
              B.NOMBRE,
              B.APE_PATE,
              B.APE_MATE,
              C.CODIGO_CUENTA,
              D.NOM_CUENTA
              
        FROM  TB_PRESTAMO A
        
        INNER JOIN TB_PERSONAS            B ON A.ID_PERSONA         = B.ID_PERSONA
        INNER JOIN TB_CUENTA              C ON A.ID_CUENTA          = C.ID_CUENTA
        INNER JOIN TB_PRODUCTO_APLICACION D ON A.ID_TIPO_APLICACION = D.ID_TIPO_APLICACION
        
        WHERE A.ESTADO = 0
        AND  (
              A.CODIGO_PRESTAMO     LIKE '%' || cTexto || '%' OR
              B.NOMBRE              LIKE '%' || cTexto || '%' OR
              B.APE_PATE            LIKE '%' || cTexto || '%' OR
              B.APE_MATE            LIKE '%' || cTexto || '%' OR
              C.CODIGO_CUENTA       LIKE '%' || cTexto || '%' 
              )
        ORDER BY A.ID_PRESTAMO DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(
        rec.FECHA_CREACION  || ', ' || rec.HORA_CREACION     || ', ' || rec.MONTO_OTORGADO  || ', ' || 
        rec.TASA_INTERES    || ', ' || rec.PLAZO             || ', ' || rec.TASA_EFECTIVA   || ', ' || 
        rec.CUOTA           || ', ' || rec.FECHA_VENCIMIENTO || ', ' || rec.FRECUENCIA_PAGO || ', ' || 
        rec.SALDO_INTERES   || ', ' || rec.SALDO_CAPITAL     || ', ' || rec.DIAS_ATRASO     || ', ' || 
        rec.SALDO_MORA      || ', ' || rec.NOMBRE            || ', ' || rec.APE_PATE        || ', ' || 
        rec.APE_MATE          || ', ' || rec.CODIGO_CUENTA   || ', ' || rec.NOM_CUENTA
        );
    END LOOP;
END;
/
--TERMINADO

--USP_GuardarPrestamo -PENDIENTE DE REVISION PARA AUTOMATIZAR PROCESOS
--17 -N°87 
CREATE OR REPLACE NONEDITIONABLE PROCEDURE USP_GuardarPrestamo(
    nOpcion             NUMBER DEFAULT 0,
    nId_Prestamo        NUMBER DEFAULT 0, --ID AUTOGENERADO
    cMontoOtorgado      NUMBER, --PARAMETROS DE ENTRADA --10,200.00
    cTasaInteres        NUMBER, --PARAMETROS DE ENTRADA --16.00
    cPlazo              NUMBER, --PARAMETROS DE ENTRADA -MESES DE PAGO --12.00
    
    nId_Persona         NUMBER DEFAULT 0, --RELACIONADO A UN CLIENTE -- id 1
    nId_Cuenta          NUMBER DEFAULT 0, --RELACIONADO A UNA CARTERA -- id 1
    nId_TipoAplicacion  NUMBER DEFAULT 0  --RELACIONADO A UN TIPO DE CUENTA -- id 1
)
AS
    --JERARQUIA DE CORBO (MORA, INTERESES Y CAPITAL)
    cTasaEfectiva       NUMBER(8,2); --(cTasaInteres/100) /((360 * 12 ) / 365)
    cCuota              NUMBER(8,2); --MONTO DE CUOTA DE CADA PAGO -MONTO_OTORGADO/((1 - (1 + TASA_EFECTIVA) ^ - NUM_CUOTAS) / TASA_EFECTIVA)
    cFechaVencimiento   DATE; --PRÓXIMA FECHA DEL PAGO -EL CLIENTE VA A DEBER TODO LO QUE SEA IGUAL O MENOR QUE HOY
    cFrecuenciaPago     VARCHAR2(50); --CADA CUANTO PAGARA EL CLIENTE -SERA MENSUAL O ANUAL
    
    cSaldoInteres       NUMBER(8,2) DEFAULT 0.00; --TOTAL DE LA SUMA DEL INTERES $$$ PAGADO
    cSaldoCapital       NUMBER(8,2) DEFAULT 0.00; --TOTAL DE LA SUMA DEL PAGO A CAPITAL | FORMULA DE PLAN DE PAGO: cCUOTA - INTERESES
    cDiasAtraso         NUMBER NULL; --DIAS DE ATRASO DE TODAS LAS CUOTAS QUE EL CLIENTE DEBE
    cSaldoMora          NUMBER(8,2); --TOTAL DE LA SUMA DE TODAS LAS MORAS DEL CLIENTE
    
    cFecha_Modificacion DATE DEFAULT SYSDATE;
    cModificado_Por     VARCHAR2(60) := NULL;
    xCodigo INT := 0;
    fFecha  DATE;
    empleado VARCHAR2(50) := NULL;
BEGIN
    SELECT 'X' INTO empleado FROM tb_usuario WHERE usuario = cModificado_Por;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        empleado := NULL;
    
    ----------------------------------------------------------------------------
    
    -- Calculando la tasa efectiva
    cTasaEfectiva := (cTasaInteres / 100) / ((360 * 12) / 365);
    
    -- Calculando la cuota
    cCuota := cMontoOtorgado / ((1 - POWER(1 + cTasaEfectiva, -cPlazo)) / cTasaEfectiva);
    
    -- Calculando la fecha de vencimiento
    SELECT ADD_MONTHS(TRUNC(SYSDATE, 'MM'), cPlazo) INTO cFechaVencimiento FROM DUAL;
    
    -- Estableciendo la frecuencia de pago
    IF cPlazo <= 12 AND cPlazo > 1 THEN
        cFrecuenciaPago := 'Mensual';
    ELSIF cPlazo > 12 THEN
        cFrecuenciaPago := 'Anual';
    END IF;
 
    ---------------------------------------------------------------------------- 
 
    IF nOpcion = 1 THEN -- Nuevo Registro
        INSERT INTO TB_PRESTAMO(
                  ID_PERSONA,
                  ID_CUENTA,
                  ID_TIPO_APLICACION,
                  MONTO_OTORGADO,
                  TASA_INTERES,
                  PLAZO,
                  TASA_EFECTIVA,
                  CUOTA,
                  FECHA_VENCIMIENTO,
                  FRECUENCIA_PAGO,
                  ESTADO
                )
        VALUES   (
                  nId_Persona,
                  nId_Cuenta,
                  nId_TipoAplicacion,
                  cMontoOtorgado,
                  cTasaInteres,
                  cPlazo,
                  cTasaEfectiva,
                  cCuota,
                  cFechaVencimiento,
                  cFrecuenciaPago,
                  1
                );
    ELSE -- Actualizar registro
        UPDATE TB_PRESTAMO
        SET
            ID_PERSONA         = nId_Persona,
            ID_CUENTA          = nId_Cuenta,
            ID_TIPO_APLICACION = nId_TipoAplicacion,
        
            MONTO_OTORGADO     = cMontoOtorgado,
            TASA_INTERES       = cTasaInteres,
            PLAZO              = cPlazo,
            TASA_EFECTIVA      = cTasaEfectiva,
            CUOTA              = cCuota,
          
            FECHA_VENCIMIENTO  = cFechaVencimiento,
            FRECUENCIA_PAGO    = cFrecuenciaPago,
            SALDO_INTERES      = cSaldoInteres,
            SALDO_CAPITAL      = cSaldoCapital,
            DIAS_ATRASO        = cDiasAtraso,
            SALDO_MORA         = cSaldoMora,
            FECHA_MODIFICACION = cFecha_Modificacion,
            MODIFICADO_POR     = cModificado_Por
        WHERE
            ID_PRESTAMO        = nId_Prestamo;
    END IF;
    
    COMMIT;
END;
/

--17 -N°88
CREATE OR REPLACE PROCEDURE USP_EliminarPrestamo(
    nId_Prestamo NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_PRESTAMO
    SET    ESTADO = 0
    WHERE  ID_PRESTAMO = nId_Prestamo;
END;
/

--17 -N°89
CREATE OR REPLACE PROCEDURE USP_LevantarPrestamo(
    nId_Prestamo NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_PRESTAMO
    SET    ESTADO = 1
    WHERE  ID_PRESTAMO = nId_Prestamo;
END;
/
--TERMINADO

-----------------------------------------------------
/* PROCEDIMIENTOS ALMACENADOS DE TB_PLAN_PAGO */
--19 -N°90
CREATE OR REPLACE PROCEDURE USP_ListadoPlanPago(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.FECHA_PAGADA,
              A.FECHA_CUOTA,
              A.CAPITAL,
              A.CAPITAL_PAGADO,
              A.INTERES,
              A.INTERES_PAGADO,
              A.NUM_CUOTAS,
              A.MORA,
              A.MORA_PAGADA,
              A.EXTRA,
              B.CODIGO_PRESTAMO
              
        FROM  TB_PLAN_PAGO A
        
        INNER JOIN TB_PRESTAMO B ON A.ID_PRESTAMO = B.ID_PRESTAMO
        
        WHERE A.ESTADO = 1
        AND   B.CODIGO_PRESTAMO LIKE '%' || cTexto || '%'
              
        ORDER BY A.ID_PLAN_PAGO DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(
        rec.FECHA_CREACION     || ', ' || rec.HORA_CREACION   || ', ' || 
        rec.FECHA_PAGADA       || ', ' || rec.FECHA_CUOTA     || ', ' || 
        rec.CAPITAL            || ', ' || rec.CAPITAL_PAGADO  || ', ' || 
        rec.INTERES            || ', ' || rec.INTERES_PAGADO  || ', ' || 
        rec.NUM_CUOTAS         || ', ' || rec.MORA            || ', ' ||
        rec.MORA               || ', ' || rec.MORA_PAGADA     || ', ' ||
        rec.EXTRA              || ', ' || rec.CODIGO_PRESTAMO
        );
    END LOOP;
END;
/

-----------------------------------------------------
/* PROCEDIMIENTOS ALMACENADOS DE TB_TRANSACCION */
--19 -N°91
CREATE OR REPLACE PROCEDURE USP_ListadoTransacciones(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.TIPO_TRANSACCION,
              A.NOM_TRANSACCION,
              B.NOM_SERVICIO
              
        FROM  TB_TRANSACCION A
        
        INNER JOIN TB_TIPO_PRODUCTO B ON A.ID_TIPO_PRODUCTO = B.ID_TIPO_PRODUCTO
        
        WHERE A.ESTADO = 1
        AND  (
              A.TIPO_TRANSACCION LIKE '%' || cTexto || '%' OR
              A.NOM_TRANSACCION  LIKE '%' || cTexto || '%' OR
              B.NOM_SERVICIO     LIKE '%' || cTexto || '%'
              )
        ORDER BY A.ID_TRANSACCION DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(
        rec.FECHA_CREACION   || ', ' || rec.HORA_CREACION     || ', ' || 
        rec.TIPO_TRANSACCION || ', ' || rec.NOM_TRANSACCION || ', ' || 
        rec.NOM_SERVICIO 
        );
    END LOOP;
END;
/

--19 -N°92
CREATE OR REPLACE PROCEDURE USP_ListadoTransaccionesCaidas(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.TIPO_TRANSACCION,
              A.NOM_TRANSACCION,
              B.NOM_SERVICIO
              
        FROM  TB_TRANSACCION A
        
        INNER JOIN TB_TIPO_PRODUCTO B ON A.ID_TIPO_PRODUCTO = B.ID_TIPO_PRODUCTO
        
        WHERE A.ESTADO = 0
        AND  (
              A.TIPO_TRANSACCION LIKE '%' || cTexto || '%' OR
              A.NOM_TRANSACCION  LIKE '%' || cTexto || '%' OR
              B.NOM_SERVICIO     LIKE '%' || cTexto || '%'
              )
        ORDER BY A.ID_TRANSACCION DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(
        rec.FECHA_CREACION   || ', ' || rec.HORA_CREACION   || ', ' || 
        rec.TIPO_TRANSACCION || ', ' || rec.NOM_TRANSACCION || ', ' || 
        rec.NOM_SERVICIO 
        );
    END LOOP;
END;
/

--19 -N°93
create or replace NONEDITIONABLE PROCEDURE USP_GuardarTransaccion(
    nOpcion             NUMBER DEFAULT 0,
    nId_Transaccion     NUMBER DEFAULT 0,
    nId_TipoProducto    NUMBER DEFAULT 0,
    cTipoTransaccion    VARCHAR2,
    cNomTransaccion     VARCHAR2
)
AS
    cFecha_Modificacion DATE DEFAULT SYSDATE;
    cModificado_Por     VARCHAR2(60) := NULL;
    xCodigo INT := 0;
    fFecha  DATE;
    empleado varchar2(50) := NULL;
BEGIN
    SELECT 'X' INTO empleado FROM tb_usuario WHERE usuario = cModificado_Por;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        empleado := NULL;
    

    IF nOpcion = 1 THEN -- Nuevo Registro
        INSERT 
        INTO 
        TB_TRANSACCION(
                  ID_TIPO_PRODUCTO,
                  TIPO_TRANSACCION,
                  NOM_TRANSACCION,
                  ESTADO
                )
        VALUES   (
                  nId_TipoProducto,
                  cTipoTransaccion,
                  cNomTransaccion,
                  1
                );
        --dbms_output.put_line('salida insert');
    ELSE -- Actualizar registro
        UPDATE TB_TRANSACCION
        SET
            ID_TIPO_PRODUCTO     = nId_TipoProducto,
            TIPO_TRANSACCION     = cTipoTransaccion,
            NOM_TRANSACCION      = cNomTransaccion,
            FECHA_MODIFICACION   = cFecha_Modificacion,
            MODIFICADO_POR       = cModificado_Por
        WHERE
            ID_TRANSACCION       = nId_Transaccion;
        --dbms_output.put_line('salida update');
end if;
commit;
END;
/

--19 -N°94
CREATE OR REPLACE PROCEDURE USP_EliminarTransaccion(
    nId_Transaccion NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_TRANSACCION
    SET    ESTADO = 0
    WHERE  ID_TRANSACCION = nId_Transaccion;
END;
/

--19 -N°95
CREATE OR REPLACE PROCEDURE USP_LevantarTransaccion(
    nId_Transaccion NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_TRANSACCION
    SET    ESTADO = 1
    WHERE  ID_TRANSACCION = nId_Transaccion;
END;
/
--TERMINADO

-----------------------------------------------------
/* PROCEDIMIENTOS ALMACENADOS DE TB_MOVIMIENTO_ABONO */
--20 -N°96
CREATE OR REPLACE PROCEDURE USP_ListadoMovimientoAbono(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.CODIGO_TRANSACCION,
              A.DESCRIPCION,
              A.TOTAL_PAGADO,
              A.CAPITAL_PAGADO,
              A.INTERES_PAGADO,
              A.MORA_PAGADA,
              B.CODIGO_CUENTA,
              C.CODIGO_PRESTAMO,
              D.NOMBRE,
              D.APE_PATE,
              D.APE_MATE,
              E.CODIGO_SUCURSAL,
              F.NOM_TRANSACCION
              
        FROM  TB_MOVIMIENTO_ABONO A
        
        INNER JOIN TB_CUENTA      B ON A.ID_CUENTA      = B.ID_CUENTA
        INNER JOIN TB_PRESTAMO    C ON A.ID_PRESTAMO    = C.ID_PRESTAMO
        INNER JOIN TB_PERSONAS    D ON A.ID_PERSONA     = D.ID_PERSONA
        INNER JOIN TB_SUCURSAL    E ON A.ID_SUCURSAL    = E.ID_SUCURSAL
        INNER JOIN TB_TRANSACCION F ON A.ID_TRANSACCION = F.ID_TRANSACCION
        
        WHERE A.ESTADO = 1
        AND  (
              A.CODIGO_TRANSACCION LIKE '%' || cTexto || '%' OR
              D.NOMBRE             LIKE '%' || cTexto || '%' OR
              D.APE_PATE           LIKE '%' || cTexto || '%' OR
              D.APE_MATE           LIKE '%' || cTexto || '%'
              )
        ORDER BY A.ID_MV_ABONO DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(
        rec.FECHA_CREACION     || ', ' || rec.HORA_CREACION   || ', ' || 
        rec.CODIGO_TRANSACCION || ', ' || rec.DESCRIPCION     || ', ' || 
        rec.TOTAL_PAGADO       || ', ' || rec.CAPITAL_PAGADO  || ', ' || 
        rec.INTERES_PAGADO     || ', ' || rec.MORA_PAGADA     || ', ' || 
        rec.CODIGO_CUENTA      || ', ' || rec.NOMBRE          || ', ' || 
        rec.APE_PATE           || ', ' || rec.APE_MATE        || ', ' || 
        rec.CODIGO_SUCURSAL    || ', ' || rec.NOM_TRANSACCION
        );
    END LOOP;
END;
/

--20 -N°97
CREATE OR REPLACE PROCEDURE USP_ListadoMovimientoAbonoCaido(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.CODIGO_TRANSACCION,
              A.DESCRIPCION,
              A.TOTAL_PAGADO,
              A.CAPITAL_PAGADO,
              A.INTERES_PAGADO,
              A.MORA_PAGADA,
              B.CODIGO_CUENTA,
              C.CODIGO_PRESTAMO,
              D.NOMBRE,
              D.APE_PATE,
              D.APE_MATE,
              E.CODIGO_SUCURSAL,
              F.NOM_TRANSACCION
              
        FROM  TB_MOVIMIENTO_ABONO A
        
        INNER JOIN TB_CUENTA      B ON A.ID_CUENTA      = B.ID_CUENTA
        INNER JOIN TB_PRESTAMO    C ON A.ID_PRESTAMO    = C.ID_PRESTAMO
        INNER JOIN TB_PERSONAS    D ON A.ID_PERSONA     = D.ID_PERSONA
        INNER JOIN TB_SUCURSAL    E ON A.ID_SUCURSAL    = E.ID_SUCURSAL
        INNER JOIN TB_TRANSACCION F ON A.ID_TRANSACCION = F.ID_TRANSACCION
        
        WHERE A.ESTADO = 0
        AND  (
              A.CODIGO_TRANSACCION LIKE '%' || cTexto || '%' OR
              D.NOMBRE             LIKE '%' || cTexto || '%' OR
              D.APE_PATE           LIKE '%' || cTexto || '%' OR
              D.APE_MATE           LIKE '%' || cTexto || '%'
              )
        ORDER BY A.ID_MV_ABONO DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(
        rec.FECHA_CREACION     || ', ' || rec.HORA_CREACION   || ', ' || 
        rec.CODIGO_TRANSACCION || ', ' || rec.DESCRIPCION     || ', ' || 
        rec.TOTAL_PAGADO       || ', ' || rec.CAPITAL_PAGADO  || ', ' || 
        rec.INTERES_PAGADO     || ', ' || rec.MORA_PAGADA     || ', ' || 
        rec.CODIGO_CUENTA      || ', ' || rec.NOMBRE          || ', ' || 
        rec.APE_PATE           || ', ' || rec.APE_MATE        || ', ' || 
        rec.CODIGO_SUCURSAL    || ', ' || rec.NOM_TRANSACCION
        );
    END LOOP;
END;
/

--SELECT*FROM tb_movimiento_abono;
--EXEC USP_GuardarMovimientoAbono(1,NULL,1,1,61,21,1,'Abono a prestamo',400.56);
--USP_GuardarMovimientoAbono -PENDIENTE DE REVISION PARA AUTOMATIZAR PROCESOS
--20 -N°98
CREATE OR REPLACE NONEDITIONABLE PROCEDURE USP_GuardarMovimientoAbono(
    nOpcion             NUMBER DEFAULT 0,
    nId_MV_Abono        NUMBER DEFAULT 0,
    nId_Cuenta          NUMBER DEFAULT 0,
    nId_Prestamo        NUMBER DEFAULT 0,
    nId_Persona         NUMBER DEFAULT 0,
    nId_Sucursal        NUMBER DEFAULT 0,
    nId_Transaccion     NUMBER DEFAULT 0,
    cDescripcion        VARCHAR2,
    cTotalPagado        NUMBER
)
AS
    cCapitalPagado      NUMBER(8,2) := 0;
    cInteresPagado      NUMBER(8,2) := 0;
    cMoraPagada         NUMBER(8,2) DEFAULT 0.00;
    nId_User            NUMBER := NULL;
    cFecha_Modificacion DATE DEFAULT SYSDATE;
    cModificado_Por     VARCHAR2(60) := 'SYSTEM';
    xCodigo             INT := 0;
    fFecha              DATE;
    empleado            VARCHAR2(50) := NULL;
BEGIN   
    IF nOpcion = 1 THEN -- Nuevo Registro
        INSERT INTO TB_MOVIMIENTO_ABONO(
            ID_CUENTA,
            ID_PRESTAMO,
            ID_USER,
            ID_PERSONA,
            ID_SUCURSAL,
            ID_TRANSACCION,
            DESCRIPCION,
            TOTAL_PAGADO,
            CAPITAL_PAGADO,
            INTERES_PAGADO,
            MORA_PAGADA,
            ESTADO
        ) VALUES (
            nId_Cuenta,
            nId_Prestamo,
            nId_User,
            nId_Persona,
            nId_Sucursal,
            nId_Transaccion,
            cDescripcion,
            cTotalPagado,
            cCapitalPagado,
            cInteresPagado,
            cMoraPagada,
            1
        );
    ELSE -- Actualizar registro
        UPDATE TB_MOVIMIENTO_ABONO
        SET
            ID_CUENTA           = nId_Cuenta,
            ID_PRESTAMO         = nId_Prestamo,
            ID_USER             = nId_User,
            ID_PERSONA          = nId_Persona,
            ID_SUCURSAL         = nId_Sucursal,
            ID_TRANSACCION      = nId_Transaccion,
            DESCRIPCION         = cDescripcion,
            TOTAL_PAGADO        = cTotalPagado,
            CAPITAL_PAGADO      = cCapitalPagado,
            INTERES_PAGADO      = cInteresPagado,
            MORA_PAGADA         = cMoraPagada,
            FECHA_MODIFICACION  = cFecha_Modificacion,
            MODIFICADO_POR      = cModificado_Por
        WHERE
            ID_MV_ABONO         = nId_MV_Abono;
    END IF;
    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
END;
/


--20 -N°99
CREATE OR REPLACE PROCEDURE USP_EliminarMovimientoAbono(
    nId_MV_Abono NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_MOVIMIENTO_ABONO
    SET    ESTADO = 0
    WHERE  ID_MV_ABONO = nId_MV_Abono;
END;
/

--20 -N°100
CREATE OR REPLACE PROCEDURE USP_LevantarMovimientoAbono(
    nId_MV_Abono NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_MOVIMIENTO_ABONO
    SET    ESTADO = 1
    WHERE  ID_MV_ABONO = nId_MV_Abono;
END;
/
--TERMINADO

-----------------------------------------------------
/* PROCEDIMIENTOS ALMACENADOS DE TB_MOVIMIENTO_CUENTA */
--21 -N°101
CREATE OR REPLACE PROCEDURE USP_ListadoMovimientoCuenta(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.DESCRIPCION,
              A.MONTO,
              B.CODIGO_CUENTA,
              C.NOMBRE,
              C.APE_PATE,
              C.APE_MATE,
              D.CODIGO_SUCURSAL,
              E.NOM_TRANSACCION
              
        FROM  TB_MOVIMIENTO_CUENTA A
        
        INNER JOIN TB_CUENTA      B ON A.ID_CUENTA      = B.ID_CUENTA
        INNER JOIN TB_PERSONAS    C ON A.ID_PERSONA     = C.ID_PERSONA
        INNER JOIN TB_SUCURSAL    D ON A.ID_SUCURSAL    = D.ID_SUCURSAL
        INNER JOIN TB_TRANSACCION E ON A.ID_TRANSACCION = E.ID_TRANSACCION
        
        WHERE A.ESTADO = 1
        AND  (
              B.CODIGO_CUENTA LIKE '%' || cTexto || '%' OR
              C.NOMBRE        LIKE '%' || cTexto || '%' OR
              C.APE_PATE      LIKE '%' || cTexto || '%' OR
              C.APE_MATE      LIKE '%' || cTexto || '%'
              )
        ORDER BY A.ID_MV_CUENTA DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(
        rec.FECHA_CREACION     || ', ' || rec.HORA_CREACION   || ', ' || 
        rec.DESCRIPCION        || ', ' || rec.MONTO           || ', ' || 
        rec.CODIGO_CUENTA      || ', ' || rec.NOMBRE          || ', ' || 
        rec.APE_PATE           || ', ' || rec.APE_MATE        || ', ' || 
        rec.CODIGO_SUCURSAL    || ', ' || rec.NOM_TRANSACCION
        );
    END LOOP;
END;
/

--21 -N°102
CREATE OR REPLACE PROCEDURE USP_ListadoMovimientoCuentaCaida(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.DESCRIPCION,
              A.MONTO,
              B.CODIGO_CUENTA,
              C.NOMBRE,
              C.APE_PATE,
              C.APE_MATE,
              D.CODIGO_SUCURSAL,
              E.NOM_TRANSACCION
              
        FROM  TB_MOVIMIENTO_CUENTA A
        
        INNER JOIN TB_CUENTA      B ON A.ID_CUENTA      = B.ID_CUENTA
        INNER JOIN TB_PERSONAS    C ON A.ID_PERSONA     = C.ID_PERSONA
        INNER JOIN TB_SUCURSAL    D ON A.ID_SUCURSAL    = D.ID_SUCURSAL
        INNER JOIN TB_TRANSACCION E ON A.ID_TRANSACCION = E.ID_TRANSACCION
        
        WHERE A.ESTADO = 0
        AND  (
              B.CODIGO_CUENTA LIKE '%' || cTexto || '%' OR
              C.NOMBRE        LIKE '%' || cTexto || '%' OR
              C.APE_PATE      LIKE '%' || cTexto || '%' OR
              C.APE_MATE      LIKE '%' || cTexto || '%'
              )
        ORDER BY A.ID_MV_CUENTA DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(
        rec.FECHA_CREACION     || ', ' || rec.HORA_CREACION   || ', ' || 
        rec.DESCRIPCION        || ', ' || rec.MONTO           || ', ' || 
        rec.CODIGO_CUENTA      || ', ' || rec.NOMBRE          || ', ' || 
        rec.APE_PATE           || ', ' || rec.APE_MATE        || ', ' || 
        rec.CODIGO_SUCURSAL    || ', ' || rec.NOM_TRANSACCION
        );
    END LOOP;
END;
/

--USP_GuardarMovimientoCuenta -PENDIENTE DE REVISION PARA AUTOMATIZAR PROCESOS
--21 -N°103
CREATE OR REPLACE NONEDITIONABLE PROCEDURE USP_GuardarMovimientoCuenta(
    nOpcion         NUMBER DEFAULT 0,
    nId_MV_Cuenta   NUMBER DEFAULT 0,
    nId_Cuenta      NUMBER DEFAULT 0,
    nId_Persona     NUMBER DEFAULT 0,
    nId_Sucursal    NUMBER DEFAULT 0,
    nId_Transaccion NUMBER DEFAULT 0,
    cDescripcion    VARCHAR2,
    cMonto          NUMBER
)
AS
    nId_User            NUMBER := NULL;
    cFecha_Modificacion DATE DEFAULT SYSDATE;
    cModificado_Por     VARCHAR2(60) := 'SYSTEM';
    xCodigo             INT := 0;
    fFecha              DATE;
    empleado            VARCHAR2(50) := NULL;
BEGIN    
    IF nOpcion = 1 THEN -- Nuevo Registro
        INSERT INTO TB_MOVIMIENTO_CUENTA(
            ID_CUENTA,
            ID_USER,
            ID_PERSONA,
            ID_SUCURSAL,
            ID_TRANSACCION,
            DESCRIPCION,
            MONTO,
            ESTADO
        ) VALUES (
            nId_Cuenta,
            nId_User,
            nId_Persona,
            nId_Sucursal,
            nId_Transaccion,
            cDescripcion,
            cMonto,
            1
        );
    ELSE -- Actualizar registro
        UPDATE TB_MOVIMIENTO_CUENTA
        SET
            ID_CUENTA           = nId_Cuenta,
            ID_USER             = nId_User,
            ID_PERSONA          = nId_Persona,
            ID_SUCURSAL         = nId_Sucursal,
            ID_TRANSACCION      = nId_Transaccion,
            DESCRIPCION         = cDescripcion,
            MONTO               = cMonto,
            FECHA_MODIFICACION  = cFecha_Modificacion,
            MODIFICADO_POR      = cModificado_Por
        WHERE
            ID_MV_CUENTA        = nId_MV_Cuenta;
    END IF;
    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
END;
/


--21 -N°104
CREATE OR REPLACE PROCEDURE USP_EliminarMovimientoCuenta(
    nId_MV_Cuenta NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_MOVIMIENTO_CUENTA
    SET    ESTADO = 0
    WHERE  ID_MV_CUENTA = nId_MV_Cuenta;
END;
/

--21 -N°105
CREATE OR REPLACE PROCEDURE USP_LevantarMovimientoCuenta(
    nId_MV_Cuenta NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_MOVIMIENTO_CUENTA
    SET    ESTADO = 1
    WHERE  ID_MV_CUENTA = nId_MV_Cuenta;
END;
/
--TEMINADO

-----------------------------------------------------
/* PROCEDIMIENTOS ALMACENADOS DE TB_MOVIMIENTO_TARJETA */
--22 -N°106
CREATE OR REPLACE PROCEDURE USP_ListadoMovimientoTarjeta(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.DESCRIPCION,
              A.MONTO,
              B.CODIGO_TARJETA,
              C.NOMBRE,
              C.APE_PATE,
              C.APE_MATE,
              D.CODIGO_SUCURSAL,
              E.NOM_TRANSACCION
              
        FROM  TB_MOVIMIENTO_TARJETA A
        
        INNER JOIN TB_TARJETA     B ON A.ID_TARJETA     = B.ID_TARJETA
        INNER JOIN TB_PERSONAS    C ON A.ID_PERSONA     = C.ID_PERSONA
        INNER JOIN TB_SUCURSAL    D ON A.ID_SUCURSAL    = D.ID_SUCURSAL
        INNER JOIN TB_TRANSACCION E ON A.ID_TRANSACCION = E.ID_TRANSACCION
        
        WHERE A.ESTADO = 1
        AND  (
              B.CODIGO_TARJETA LIKE '%' || cTexto || '%' OR
              C.NOMBRE         LIKE '%' || cTexto || '%' OR
              C.APE_PATE       LIKE '%' || cTexto || '%' OR
              C.APE_MATE       LIKE '%' || cTexto || '%'
              )
        ORDER BY A.ID_MV_TARJETA DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(
        rec.FECHA_CREACION     || ', ' || rec.HORA_CREACION   || ', ' || 
        rec.DESCRIPCION        || ', ' || rec.MONTO           || ', ' || 
        rec.CODIGO_TARJETA     || ', ' || rec.NOMBRE          || ', ' || 
        rec.APE_PATE           || ', ' || rec.APE_MATE        || ', ' || 
        rec.CODIGO_SUCURSAL    || ', ' || rec.NOM_TRANSACCION
        );
    END LOOP;
END;
/

--22 -N°107
CREATE OR REPLACE PROCEDURE USP_ListadoMovimientoTarjetaCaida(
    cTexto IN VARCHAR2 DEFAULT ''
)
AS
BEGIN
    FOR rec IN (
        SELECT
              A.FECHA_CREACION,
              A.HORA_CREACION,
              A.DESCRIPCION,
              A.MONTO,
              B.CODIGO_TARJETA,
              C.NOMBRE,
              C.APE_PATE,
              C.APE_MATE,
              D.CODIGO_SUCURSAL,
              E.NOM_TRANSACCION
              
        FROM  TB_MOVIMIENTO_TARJETA A
        
        INNER JOIN TB_TARJETA     B ON A.ID_TARJETA     = B.ID_TARJETA
        INNER JOIN TB_PERSONAS    C ON A.ID_PERSONA     = C.ID_PERSONA
        INNER JOIN TB_SUCURSAL    D ON A.ID_SUCURSAL    = D.ID_SUCURSAL
        INNER JOIN TB_TRANSACCION E ON A.ID_TRANSACCION = E.ID_TRANSACCION
        
        WHERE A.ESTADO = 0
        AND  (
              B.CODIGO_TARJETA LIKE '%' || cTexto || '%' OR
              C.NOMBRE         LIKE '%' || cTexto || '%' OR
              C.APE_PATE       LIKE '%' || cTexto || '%' OR
              C.APE_MATE       LIKE '%' || cTexto || '%'
              )
        ORDER BY A.ID_MV_TARJETA DESC
    ) LOOP
        DBMS_OUTPUT.PUT_LINE(
        rec.FECHA_CREACION     || ', ' || rec.HORA_CREACION   || ', ' || 
        rec.DESCRIPCION        || ', ' || rec.MONTO           || ', ' || 
        rec.CODIGO_TARJETA     || ', ' || rec.NOMBRE          || ', ' || 
        rec.APE_PATE           || ', ' || rec.APE_MATE        || ', ' || 
        rec.CODIGO_SUCURSAL    || ', ' || rec.NOM_TRANSACCION
        );
    END LOOP;
END;
/

--USP_GuardarMovimientoTarjeta -PENDIENTE DE REVISION PARA AUTOMATIZAR PROCESOS
--22 -N°108
CREATE OR REPLACE NONEDITIONABLE PROCEDURE USP_GuardarMovimientoTarjeta(
    nOpcion         NUMBER DEFAULT 0,
    nId_MV_Tarjeta  NUMBER DEFAULT 0,
    nId_Tarjeta     NUMBER DEFAULT 0,
    nId_Persona     NUMBER DEFAULT 0,
    nId_Sucursal    NUMBER DEFAULT 0,
    nId_Prestamo    NUMBER DEFAULT 0,
    nId_Transaccion NUMBER DEFAULT 0,
    cDescripcion    VARCHAR2,
    cMonto          NUMBER
)
AS
    nId_User            NUMBER := NULL;
    cFecha_Modificacion DATE DEFAULT SYSDATE;
    cModificado_Por     VARCHAR2(60) := 'SYSTEM';
    xCodigo             INT := 0;
    fFecha              DATE;
    empleado            VARCHAR2(50) := NULL;
BEGIN
    IF nOpcion = 1 THEN -- Nuevo Registro
        INSERT INTO TB_MOVIMIENTO_TARJETA(
            ID_TARJETA,
            ID_USER,
            ID_SUCURSAL,
            ID_PERSONA,
            ID_PRESTAMO,
            ID_TRANSACCION,
            DESCRIPCION,
            MONTO,
            ESTADO
        ) VALUES (
            nId_Tarjeta,
            nId_User,
            nId_Sucursal,
            nId_Persona,
            nId_Prestamo,
            nId_Transaccion,
            cDescripcion,
            cMonto,
            1
        );
    ELSE -- Actualizar registro
        UPDATE TB_MOVIMIENTO_TARJETA
        SET
            ID_TARJETA          = nId_Tarjeta,
            ID_USER             = nId_User,
            ID_SUCURSAL         = nId_Sucursal,
            ID_PERSONA          = nId_Persona,
            ID_PRESTAMO         = nId_Prestamo,
            ID_TRANSACCION      = nId_Transaccion,
            DESCRIPCION         = cDescripcion,
            MONTO               = cMonto,
            FECHA_MODIFICACION  = cFecha_Modificacion,
            MODIFICADO_POR      = cModificado_Por
        WHERE
            ID_MV_TARJETA       = nId_MV_Tarjeta;
    END IF;
    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
END;
/


--22 -N°109
CREATE OR REPLACE PROCEDURE USP_EliminarMovimientoTarjeta(
    nId_MV_Tarjeta NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_MOVIMIENTO_TARJETA
    SET    ESTADO = 0
    WHERE  ID_MV_TARJETA = nId_MV_Tarjeta;
END;
/

--22 -N°110
CREATE OR REPLACE PROCEDURE USP_LevantarMovimientoTarjeta(
    nId_MV_Tarjeta NUMBER DEFAULT 0
)
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TB_MOVIMIENTO_TARJETA
    SET    ESTADO = 1
    WHERE  ID_MV_TARJETA = nId_MV_Tarjeta;
END;
/
--TERMINADO