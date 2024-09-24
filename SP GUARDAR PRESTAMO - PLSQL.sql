--------------------------------------------------------
-- Archivo creado  - lunes-mayo-06-2024   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Procedure USP_GUARDARPRESTAMO
--------------------------------------------------------
set define off;

  CREATE OR REPLACE NONEDITIONABLE PROCEDURE "BANCACAPITAL"."USP_GUARDARPRESTAMO" (
    nOpcion             NUMBER DEFAULT 0,
    nId_Prestamo        NUMBER DEFAULT 0, --ID AUTOGENERADO
    cMontoOtorgado      NUMBER, --PARAMETROS DE ENTRADA
    cTasaInteres        NUMBER, --PARAMETROS DE ENTRADA
    cPlazo              NUMBER, --PARAMETROS DE ENTRADA -MESES DE PAGO
    
    nId_Persona         NUMBER DEFAULT 0, --RELACIONADO A UN CLIENTE
    nId_Cuenta          NUMBER DEFAULT 0, --RELACIONADO A UNA CARTERA
    nId_TipoAplicacion  NUMBER DEFAULT 0  --RELACIONADO A UN TIPO DE CUENTA
)
AS
    --JERARQUIA DE CORBO (MORA, INTERESES Y CAPITAL)
    cTasaEfectiva       NUMBER(8,2); --(cTasaInteres/100) /((360 * 12 ) / 365)
    cCuota              NUMBER(8,2); --MONTO DE CUOTA DE CADA PAGO -MONTO_OTORGADO/((1 - (1 + TASA_EFECTIVA) ^ - NUM_CUOTAS) / TASA_EFECTIVA)
    cFechaVencimiento   DATE; --PRÓXIMA FECHA DEL PAGO -EL CLIENTE VA A DEBER TODO LO QUE SEA IGUAL O MENOR QUE HOY
    cFrecuenciaPago     VARCHAR2(50); --CADA CUANTO PAGARA EL CLIENTE

    cSaldoInteres       NUMBER(8,2) DEFAULT 0.00; --TOTAL DE LA SUMA DEL INTERES $$$ PAGADO
    cSaldoCapital       NUMBER(8,2) DEFAULT 0.00; --cCUOTA - INTERESES
    cDiasAtraso         NUMBER; --DIAS DE ATRASO DE TODAS LAS CUOTAS QUE EL CLIENTE DEBE
    cSaldoMora          NUMBER(8,2); --TOTAL DE LA SUMA DE TODAS LAS MORAS DEL CLIENTE

    cFecha_Modificacion DATE DEFAULT SYSDATE;
    cModificado_Por     VARCHAR2(50);
    xCodigo INT := 0;
    fFecha  DATE;
    empleado VARCHAR2(50) := NULL;
BEGIN
    SELECT 'X' INTO empleado FROM tb_usuario WHERE usuario = cModificado_Por;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        empleado := NULL;

    -- Calculando la tasa efectiva
    cTasaEfectiva := (cTasaInteres / 100) / ((360 * 12) / 365);

    -- Calculando la cuota
    cCuota := cMontoOtorgado / ((1 - POWER((1 + cTasaEfectiva), -cPlazo)) / cTasaEfectiva);

    -- Calculando la fecha de vencimiento
    SELECT ADD_MONTHS(TRUNC(SYSDATE, 'MM'), cPlazo) INTO cFechaVencimiento FROM DUAL;

    -- Estableciendo la frecuencia de pago
    IF cPlazo <= 12 AND cPlazo > 1 THEN
        cFrecuenciaPago := 'Mensual';
    ELSIF cPlazo > 12 THEN
        cFrecuenciaPago := 'Anual';
    END IF;

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
