--COMANDO PARA ELIMINAR TODAS LAS TABLAS DE UNA CONEXIÓN DE ORACLE XE
BEGIN FOR c IN (SELECT table_name FROM user_tables) 
LOOP EXECUTE IMMEDIATE ('DROP TABLE "' || c.table_name || '" CASCADE constraints'); 
END LOOP; 
FOR s IN (SELECT sequence_name FROM user_sequences) 
LOOP EXECUTE IMMEDIATE ('DROP SEQUENCE ' || s.sequence_name); 
END LOOP; 
END;
