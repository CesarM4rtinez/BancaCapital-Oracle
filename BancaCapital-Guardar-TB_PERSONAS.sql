create or replace NONEDITIONABLE PROCEDURE USP_GuardarPersonas(
    nOpcion             NUMBER DEFAULT 0,
    nId_Persona         NUMBER DEFAULT 0,
    nId_TipoCliente     NUMBER DEFAULT 0,
    nId_Identificacion  NUMBER DEFAULT 0,
    nId_Pais            NUMBER DEFAULT 0,
    nId_EstadoCivil     NUMBER DEFAULT 0,
    nId_RangoIngreso    NUMBER DEFAULT 0,
    nId_Moneda          NUMBER DEFAULT 0,
    nId_Sucursal        NUMBER DEFAULT 0,
    
    cNombre             IN VARCHAR2,
    cApePate            IN VARCHAR2,
    cApeMate            IN VARCHAR2,
    cFechaNac           IN DATE,
    cDireccionRes       IN VARCHAR2,
    cTelCel             IN VARCHAR2,
    cTelFijo            IN VARCHAR2,
    cCorreoElectronico  IN VARCHAR2,
    cSexo               IN NUMBER,
    cNumIdentificacion  IN VARCHAR2,
    cFechaExpiracionIDE IN DATE,
    cCargoTrabajo       IN VARCHAR2,
    cEmpleado           IN NUMBER
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
            nId_Sucursal,
        
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
            cEmpleado,
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
            ID_SUCURSAL         = nId_Sucursal,
            
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
COMMIT;
END;
/

EXEC USP_GUARDARPERSONAS
(1, --nOpcion
NULL, --nId_Persona
1, --nId_TipoCliente
1, --nId_Identificacion
1, --nId_Pais
1, --nId_EstadoCivil
7, --nId_RangoIngreso
1, --nId_Moneda
1, --nId_Sucursal
'Lisbeth Angelica', --cNombre
'Cortez', --cApePate
'Mejia', --cApeMate
'1975/25/08', --cFechaNac
'San Salvador', --cDireccionRes
'7604-1405', --cTelCel
'6785-6994', --cTelFijo
'lizbethangelica.cortez@unab.edu.sv', --cCorreoElectronico
0, --cSexo
'09009876-9', --cNumIdentificacion
'2025/25/08', --cFechaExpiracionIDE
'Docente', --cCargoTrabajo
0 --cEmpleado
);

EXEC USP_GUARDARPAISES(1,NULL,'México', '+52');

SELECT*FROM TB_PERSONAS