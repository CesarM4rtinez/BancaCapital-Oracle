/* TRIGGERS DE TB_PLAN_PAGO */

/*
Este trigger se activar� despu�s de que se inserte un nuevo pr�stamo en la tabla TB_PRESTAMO. 
Insertar� autom�ticamente un registro en la tabla TB_PLAN_PAGO con los valores correspondientes 
al nuevo pr�stamo, como la fecha actual como fecha de pago y cuota, la cuota del pr�stamo como 
capital y el saldo de intereses como inter�s. Puedes ajustar los valores seg�n tus necesidades 
comerciales espec�ficas.
*/

CREATE OR REPLACE TRIGGER TR_CREAR_PLANPAGO 
AFTER INSERT ON TB_PRESTAMO
FOR EACH ROW
BEGIN
bCuota NUMBER;  
bCuota = :NEW.PLAZO;
FOR X IN 1..cPlazo LOOP 

  INSERT INTO TB_PLAN_PAGO (
    ID_PRESTAMO,
    FECHA_PAGADA,
    FECHA_CUOTA,
    CAPITAL,
    INTERES,
    NUM_CUOTAS,
    ESTADO
  ) VALUES (
    :new.ID_PRESTAMO,
    SYSDATE, -- Puedes ajustar estas fechas seg�n tus reglas de negocio
    SYSDATE,
    :new.CUOTA_PRESTAMO,
    :new.SALDO_INTERES,
    :new.NUM_CUOTAS,
    1
  );
END LOOP;
END;
/

/*
CREAR O REEMPLAZAR DISPARADOR Print_salary_changes
ANTES DE ELIMINAR O INSERTAR O ACTUALIZAR EN Emp_tab
POR CADA FILA
CUANDO (nuevo.Empno > 0)
DECLARAR
n�mero sal_diff;
COMENZAR
sal_diff := :nueva.sal - :antigua.sal;
dbms_output.put('Salario anterior: ' || :old.sal);
dbms_output.put(' Nuevo salario: ' || :new.sal);
dbms_output.put_line('Diferencia' || sal_diff);
FIN;
*/
