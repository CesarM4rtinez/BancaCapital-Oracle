DECLARE
  NOPCION NUMBER;
  NID_PERSONA NUMBER;
  NID_TIPOCLIENTE NUMBER;
  NID_IDENTIFICACION NUMBER;
  NID_PAIS NUMBER;
  NID_ESTADOCIVIL NUMBER;
  NID_RANGOINGRESO NUMBER;
  NID_MONEDA NUMBER;
  NID_SUCURSAL NUMBER;
  CNOMBRE VARCHAR2(200);
  CAPEPATE VARCHAR2(200);
  CAPEMATE VARCHAR2(200);
  CFECHANAC DATE;
  CDIRECCIONRES VARCHAR2(200);
  CTELCEL VARCHAR2(200);
  CTELFIJO VARCHAR2(200);
  CCORREOELECTRONICO VARCHAR2(200);
  CSEXO NUMBER;
  CNUMIDENTIFICACION VARCHAR2(200);
  CFECHAEXPIRACIONIDE DATE;
  CCARGOTRABAJO VARCHAR2(200);
  CEMPLEADO NUMBER;
BEGIN
  NOPCION := 1;
  NID_PERSONA := NULL;
  NID_TIPOCLIENTE := 1;
  NID_IDENTIFICACION := 1;
  NID_PAIS := 1;
  NID_ESTADOCIVIL := 1;
  NID_RANGOINGRESO := 1;
  NID_MONEDA := 1;
  NID_SUCURSAL := 1;
  CNOMBRE := 'Lizbeth Angelica';
  CAPEPATE := 'Cortez';
  CAPEMATE := 'Mejia';
  CFECHANAC := NULL;
  CDIRECCIONRES := NULL;
  CTELCEL := NULL;
  CTELFIJO := NULL;
  CCORREOELECTRONICO := NULL;
  CSEXO := NULL;
  CNUMIDENTIFICACION := NULL;
  CFECHAEXPIRACIONIDE := NULL;
  CCARGOTRABAJO := NULL;
  CEMPLEADO := NULL;

  USP_GUARDARPERSONAS(
    NOPCION => NOPCION,
    NID_PERSONA => NID_PERSONA,
    NID_TIPOCLIENTE => NID_TIPOCLIENTE,
    NID_IDENTIFICACION => NID_IDENTIFICACION,
    NID_PAIS => NID_PAIS,
    NID_ESTADOCIVIL => NID_ESTADOCIVIL,
    NID_RANGOINGRESO => NID_RANGOINGRESO,
    NID_MONEDA => NID_MONEDA,
    NID_SUCURSAL => NID_SUCURSAL,
    CNOMBRE => CNOMBRE,
    CAPEPATE => CAPEPATE,
    CAPEMATE => CAPEMATE,
    CFECHANAC => CFECHANAC,
    CDIRECCIONRES => CDIRECCIONRES,
    CTELCEL => CTELCEL,
    CTELFIJO => CTELFIJO,
    CCORREOELECTRONICO => CCORREOELECTRONICO,
    CSEXO => CSEXO,
    CNUMIDENTIFICACION => CNUMIDENTIFICACION,
    CFECHAEXPIRACIONIDE => CFECHAEXPIRACIONIDE,
    CCARGOTRABAJO => CCARGOTRABAJO,
    CEMPLEADO => CEMPLEADO
  );
--rollback; 
END;
