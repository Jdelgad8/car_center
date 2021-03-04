Create Table pais(
	cod_pais Number(2) Not Null,
	descripcion Varchar(60) Not Null,
    Constraint pk_pais Primary Key (cod_pais)
);

Insert Into pais Values(
    '01',
	'colombia'
);

Insert Into pais Values(
    '02',
	'peru'
);

Create Table departamento(
	cod_dep Number(2) Not Null,
	cod_pais Number(2) Not Null,
	descripcion Varchar(60) Not Null,
    Constraint pk_dep Primary Key (cod_dep),
    Constraint fk_dep_cod_pais
      Foreign Key (cod_pais)
      References pais(cod_pais)
);

Insert Into departamento Values(
	'01',
    '01',
	'cundinamarca'
);

Insert Into departamento Values(
	'02',
    '01',
	'meta'
);

Insert Into departamento Values(
	'03',
    '01',
	'antioquia'
);

Create Table ciudad(
	cod_ciu Number(2) Not Null,
	cod_dep Number(2) Not Null,
	descripcion Varchar(60) Not Null,
    Constraint pk_ciudad Primary Key (cod_ciu),
    Constraint fk_ciu_cod_dep
      Foreign Key (cod_dep)
      References departamento(cod_dep)
);

Insert Into ciudad Values(
	'01',
    '01',
	'bogota'
);

Insert Into ciudad Values(
	'02',
    '02',
	'villavicencio'
);

Insert Into ciudad Values(
	'03',
    '03',
	'medellin'
);

Create Table zonaT(
	cod_zona Number(2) Not Null,
	cod_ciu Number(2) Not Null,
	nom_zona Varchar(20) Not Null,
    Constraint pk_zona Primary Key (cod_zona),
    Constraint fk_cod_ciu
      Foreign Key (cod_ciu)
      References ciudad(cod_ciu)
);

Insert Into zonaT Values(
	'01',
    '01',
	'usaquen'
);


Insert Into zonaT Values(
	'02',
    '01',
	'suba'
);


Insert Into zonaT Values(
	'03',
    '02',
	'7 de agosto'
);

Insert Into zonaT Values(
	'04',
    '03',
	'laureles'
);

Create Table taller(
	cod_taller Number(8) Not Null,
	cod_zona Number(2) Not Null,
	nro_cel Varchar(20) Not Null,
	direccion Varchar(60) Not Null,	
	fec_reg date Not Null,
    Constraint pk_taller Primary Key (cod_taller),
    Constraint fk_cod_zona
      Foreign Key (cod_zona)
      References zonaT(cod_zona)
);

Create Table tipo_doc (
	tipo_doc Varchar(2) Not Null Primary Key,
	-- Cédula de ciudadanía, Pasaporte, etc.
	descripcion Varchar(60) Not Null
);

Insert Into tipo_doc Values (
	'cc',
	'cedula de ciudadania'
);

Insert Into tipo_doc Values (
	'pa',
	'pasaporte'
);

Create Table cliente(
	cod_cli Number(8) Not Null,
	cod_zona Number(2) Not Null,
	tipo_doc Varchar(2) Not Null,
	prim_nom Varchar(20) Not Null,
	segu_nom Varchar(20),
	prim_ape Varchar(20) Not Null,
	segu_ape Varchar(20) Not Null,
	nro_doc Varchar(20) Not Null,
	nro_cel Varchar(20) Not Null,
	direccion Varchar(60) Not Null,
	email Varchar(60) Not Null,
	vlr_max Float,
	fec_reg Date Not Null,
    Constraint pk_cliente Primary Key (cod_cli),
    Constraint fk_cod_zona_cli
      Foreign Key (cod_zona)
      References zonaT(cod_zona),
    Constraint fk_tipo_doc
      Foreign Key (tipo_doc)
      References tipo_doc(tipo_doc)
);

Insert Into cliente Values (
    '01',
	1,
	'cc',
	'Jordy',
	'Harickson',
	'Delgado',
	'Leon',
	'1001093926',
	'3207850855',
	'Cra 14A Este # 48 - 28. Torre 24 Apto 102',
	'jordydelgado@hotmail.com',
	100000.0,
	sysdate
);

Create Table tipo_mecanico(
	cod_tipo Number(2) Not Null,
	-- Mecánico, Latonero, PNumber(8)or, etc.
	descripcion Varchar(60) Not Null,
    Constraint pk_tipo_mec Primary Key (cod_tipo)
);

Create Table tipo_servicio(
	cod_tipo Number(2) Not Null,
	-- Arreglo, mantenimiento, mejora, adaptación, etc.
	descripcion Varchar(60) Not Null,
    Constraint pk_tipo_ser Primary Key (cod_tipo)
);

Create Table servicioT(
	cod_ser Number(2) Not Null,
	cod_tipo Number(2) Not Null,
	vlr_min Float Not Null,
	vlr_max Float Not Null,
	-- Duración mínima del servicio en horas
	dur_min Number(8) Not Null,
    Constraint pk_servicio Primary Key (cod_ser),
    Constraint fk_ser_tipo_ser
      Foreign Key (cod_tipo)
      References tipo_servicio(cod_tipo)
);

Create Table estado_mecanico(
	cod_est_mec Varchar(3) Not Null,
	-- Activo, en vacaciones, retirado, incapacitado, etc.
	descripcion Varchar(60) Not Null,
    Constraint pk_est_mec Primary Key (cod_est_mec)
);

Create Table mecanico(
	cod_mec Number(8) Not Null,
	cod_zona Number(2) Not Null,
	cod_taller Number(8) Not Null,
	cod_tipo Number(2) Not Null, 	
	tipo_doc Varchar(2) Not Null,
    cod_est_mec Varchar(3) Not Null,
	prim_nom Varchar(20) Not Null,
	segu_nom Varchar(20) ,
	prim_ape Varchar(20) Not Null,
	segu_ape Varchar(20) Not Null,	
	nro_doc Varchar(20) Not Null,
	nro_cel Varchar(20) Not Null,
	direccion Varchar(60) Not Null,
	email Varchar(60) Not Null,
	fec_reg Date Not Null,
    Constraint pk_mecanico Primary Key (cod_mec),
    Constraint fk_mec_cod_zona
      Foreign Key (cod_zona)
      References zonaT(cod_zona),
    Constraint fk_mec_cod_taller
      Foreign Key (cod_taller)
      References taller(cod_taller),
    Constraint fk_mec_cod_tipo
      Foreign Key (cod_tipo)
      References tipo_mecanico(cod_tipo),
    Constraint fk_mec_tipo_doc
      Foreign Key (tipo_doc)
      References tipo_doc(tipo_doc),
    Constraint fk_mec_cod_est_mec
      Foreign Key (cod_est_mec)
      References estado_mecanico(cod_est_mec)
);

Create Table ser_mecanico(
	cod_ser Number(2) Not Null,
	cod_mec Number(8) Not Null,
    Constraint pk_ser_mec Primary Key(cod_ser, cod_mec)
);

Create Table vehiculo(
	cod_veh Number(8) Not Null,
	placa Varchar(20) Not Null,
	marca Varchar(20) Not Null,
	modelo Date Not Null,
	color Varchar(20) Not Null,
    Constraint pk_vehiculo Primary Key (cod_veh)
);

Create Table vehiculo_cliente(
	cod_veh Number(8) Not Null,
	cod_cli Number(8) Not Null,
    Constraint pk_veh_cli Primary Key(cod_veh, cod_cli)
);

Create Table est_vehiculo(
	cod_est_veh Number(8) Not Null,
	cod_veh Number(8) Not Null,
	descripcion Varchar(500),
	url_img Varchar(500) Not Null,
    Constraint pk_est_vehiculo Primary Key (cod_est_veh),
    Constraint fk_est_veh_cod_veh
      Foreign Key (cod_veh)
      References vehiculo(cod_veh)
);

Create Table calidad_repuesto(
	cod_cal_rep Number(2) Not Null,
	-- Original, importado, genérico, etc.
	descripcion Varchar(20) Not Null,
    Constraint pk_cal_rep Primary Key (cod_cal_rep)
);

Create Table tipo_repuesto(
	cod_tipo Number(2) Not Null,
	-- Frenos, embragues, suspension, motor, etc.
	descripcion Varchar(60) Not Null,
    Constraint pk_tipo_rep Primary Key (cod_tipo)
);

Create Table repuesto(
	cod_rep Number(8) Not Null,
	cod_tipo Number(2) Not Null,
	-- Código de la calidad del repuesto
	cod_cal_rep Number(2) Not Null,
	nom_rep Varchar(20) Not Null,
	vlr_rep Float Not Null,
    Constraint pk_repuesto Primary Key (cod_rep),
    Constraint fk_rep_cod_tipo
      Foreign Key (cod_tipo)
      References tipo_repuesto(cod_tipo),
    Constraint fk_rep_cod_cal_rep
      Foreign Key (cod_cal_rep)
      References calidad_repuesto(cod_cal_rep)
);

Create Table estado_servicio(
	cod_est_serv Varchar(3) Not Null,
	-- Solicitado, en proceso, terminado
	descripcion Varchar(60) Not Null,
    Constraint pk_est_serv Primary Key (cod_est_serv)
);

Create Table solicitud_serv(
	cod_solic Number(8) Not Null,
	cod_ser Number(2) Not Null,
	cod_veh Number(8) Not Null,
	cod_mec Number(8) Not Null,
	cod_est_serv Varchar(3),
	-- Valor de la mano de obra
	vlr_ser Float Not Null,	
	fec_sol Date Not Null,
	fec_est Date Not Null,
	fec_ter Date,
    Constraint pk_solicitud_serv Primary Key (cod_solic),
    Constraint fk_sol_ser_cod_ser
      Foreign Key (cod_ser)
      References servicioT(cod_ser),
    Constraint fk_sol_ser_cod_veh
      Foreign Key (cod_veh)
      References vehiculo(cod_veh),
    Constraint fk_sol_ser_cod_mec
      Foreign Key (cod_mec)
      References mecanico(cod_mec),
    Constraint fk_sol_ser_cod_est_serv
      Foreign Key (cod_est_serv)
      References estado_servicio(cod_est_serv)
);

Create Table solicitud_ser_repuesto(
	cod_sol_ser_rep Number(8) Not Null,
	cod_solic Number(8) Not Null,
	cod_rep Number(8) Not Null,
	cantidad Number(3) Not Null,
    Constraint pk_sol_ser_rep Primary Key (cod_sol_ser_rep),
    Constraint fk_sol_ser_rep_cod_sol
      Foreign Key (cod_solic)
      References solicitud_serv(cod_solic),
Constraint fk_sol_ser_rep_cod_rep
      Foreign Key (cod_rep)
      References repuesto(cod_rep)
);

Create Table inventario_repuesto(
	cod_rep Number(8) Not Null,
	cod_taller Number(8) Not Null,
	cantidad Number(8) Not Null,
	-- Fecha de actualización de inventario
	fec_act Date Not Null,
    Constraint pk_inv_rep Primary Key(cod_rep, cod_taller)
);

Create Table dcto_factura(
	cod_dcto Number(2) Not Null,
	vlr_min_dcto Float Not Null,
	porc_dcto Float Not Null,
    Constraint pk_dcto_fact Primary Key (cod_dcto)
);

Create Table est_factura(
	cod_est_fac Varchar(3) Not Null,
	-- Anulada, cancelada, finalizada, generada, etc.
	descripcion Varchar(20) Not Null,
    Constraint pk_est_fac Primary Key (cod_est_fac)
);

Create Table medio_pago(
	cod_pago Number(2) Not Null,
	-- Efectivo, Débito, Crédito, Bitcoin
	descripcion Varchar(60) Not Null,
    Constraint pk_pago Primary Key (cod_pago)
);

Create Table factura_enca(
	cod_fac_enc Number(8) Not Null,
	cod_est_fac Varchar(3) Not Null,
	cod_cli Number(8) Not Null,
	cod_mec Number(8) Not Null,
	cod_pago Number(8) Not Null,
	vlr_dcto Float,
	fec_fac date Not Null,
	vlr_tot Float Not Null,
	vlr_iva Float Not Null,
    Constraint pk_fac_enc Primary Key (cod_fac_enc),
    Constraint fk_fac_enc_cod_est_fac
      Foreign Key (cod_est_fac)
      References est_factura(cod_est_fac),
    Constraint fk_fac_enc_cod_cli
      Foreign Key (cod_cli)
      References cliente(cod_cli),
    Constraint fk_fac_enc_cod_mec
      Foreign Key (cod_mec)
      References mecanico(cod_mec),
    Constraint fk_fac_enc_cod_pago
      Foreign Key (cod_pago)
      References medio_pago(cod_pago)
);

Create Table factura_deta(
	cod_fac_det Number(8) Not Null,
	cod_fac_enc Number(8) Not Null,
	cod_solic Number(8) Not Null,
	cod_sol_ser_rep Number(8) Not Null,
	vlr_sub Number(8) Not Null,
    Constraint pk_fac_det Primary Key (cod_fac_det),
    Constraint fk_fac_det_cod_fac_enc
      Foreign Key (cod_fac_enc)
      References factura_enca(cod_fac_enc),
    Constraint fk_fac_det_cod_solic
      Foreign Key (cod_solic)
      References solicitud_serv(cod_solic),
    Constraint fk_fac_det_cod_sol_ser_rep
      Foreign Key (cod_sol_ser_rep)
      References solicitud_ser_repuesto(cod_sol_ser_rep)
);


