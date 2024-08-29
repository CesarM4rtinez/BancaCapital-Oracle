--SELECT*FROM TB_TRANSACCION;
--SELECT*FROM TB_TIPO_PRODUCTO;

EXEC USP_GuardarTransaccion(1,NULL,1,'Deposito de cuenta',    'Prestamo Financiera');
EXEC USP_GuardarTransaccion(1,NULL,1,'Retiro de cuenta',      'Retiro de cuenta');
EXEC USP_GuardarTransaccion(1,NULL,1,'Apertura de cuenta',    '');
EXEC USP_GuardarTransaccion(1,NULL,1,'Cancelacion de cuenta', '');
EXEC USP_GuardarTransaccion(1,NULL,1,'Desembolso de prestamo','');
EXEC USP_GuardarTransaccion(1,NULL,1,'Abono a prestamo',      '');

--SI ES DE DEBITO ES UNA DISMINUCION
--SI ES DE CREDITO ES UN AUMENTO
EXEC USP_GuardarTransaccion(1,NULL,1,'Credito', 'Abonos');
EXEC USP_GuardarTransaccion(1,NULL,1,'Debito',  'Retiros');