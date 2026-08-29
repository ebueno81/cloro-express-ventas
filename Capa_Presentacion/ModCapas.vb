Imports Capa_Entidades
Imports Capa_Negocios
Module ModCapas
    Public c_Neg_MnArticulo As New Neg_MnArticulos
    Public c_Neg_MnLineas As New Neg_MnLinea
    Public c_Neg_MnCliente As New Neg_MnCliente
    Public c_Neg_MnClienteOfi As New Neg_MnClienteOfi
    Public c_Neg_MnIgv As New Neg_MnIgv
    Public c_Neg_MnVendedor As New Neg_MnVendedor
    Public c_Neg_MnSeriesDoc As New Neg_MnSeriesDoc
    Public c_Neg_TpoDoc As New Neg_MnTpoDoc
    Public c_Neg_TpoCambio As New Neg_MnTpoCambio
    Public c_Neg_MnClienteArt As New Neg_MnClienteArt
    Public c_Neg_MnChofer As New Neg_MnChofer
    Public c_Neg_TpoMoneda As New Neg_MnMonedas
    Public c_Neg_Series As New Neg_MnSeriesDoc
    Public c_Neg_MnUniMed As New Neg_MnUniMed
    Public c_Neg_MnProve As New Neg_MnProve
    Public c_Neg_MnFamilia As New Neg_MnFamilia : Public c_Neg_MnSFamilia As New Neg_MnSFamilia
    Public c_Neg_MnTpoPago As New Neg_MnTpoPago
    Public c_Neg_MnAreas As New Neg_MnAreas
    Public c_Neg_Modulos As New Neg_Modulos

    Public c_Neg_MnTblGral As New Neg_MnTblGral
    Public c_Neg_MnCaidas As New Neg_MnCaidas
    Public c_Neg_MnScaidas As New Neg_Scaidas

    Public c_Neg_FactCab As New Neg_FactCab : Public c_Neg_FactDet As New Neg_FactDet : Public c_Neg_FactGuia As New Neg_FactGuia
    Public c_Neg_FactCuota As New Neg_FactCuota
    Public c_Neg_FactAnexo As New Neg_FactAnexo

    Public c_Neg_BolCab As New Neg_BolCab : Public c_Neg_BolDet As New Neg_BolDet : Public c_Neg_BolGuia As New Neg_BolGuia
    Public c_Neg_BolAnexo As New Neg_BolAnexo

    Public c_Neg_NotaC As New Neg_NotaC
    Public c_Neg_NotaD As New Neg_NotaD
    Public c_Neg_MnSeries As New Neg_MnSeriesDoc

    Public c_Neg_FactElectCab As New Neg_FactElectCab

    Public c_Neg_LetCab As New Neg_LetCab : Public c_Neg_LetDet As New Neg_LetDet
    Public c_Neg_RetenCab As New Neg_RetenCab : Public c_Neg_RetenDet As New Neg_RetenDet
    Public c_Neg_Retencion As New Neg_Retencion
    Public c_Neg_ComisDocs As New Neg_ComisDocs
    
    Public c_Neg_StatusLetra As New Neg_MnStatusLetra
    Public c_Neg_Liquidac As New Neg_Liquidac
    Public c_Neg_MnBcos As New Neg_MnBcos
    Public c_Neg_RptVtasTdas As New Neg_RptVtasTdas
    Public c_Neg_ComisCab As New Neg_ComisCab : Public c_Neg_ComisDet As New Neg_ComisDet
    Public c_Neg_AlmSalTA As New Neg_AlmSalTa : Public c_Neg_AlmSalTADet As New Neg_AlmSalTaDet
    Public c_Neg_AlmSalTAAnexo As New Neg_AlmSalTaAnexo

    Public c_Neg_Usuario As New Neg_Usuario
    Public c_Neg_MnEmpresa As New Neg_MnEmpresa
    Public c_Neg_mnmtmov As New Neg_MnMtMov
    Public c_Neg_Apertura As New Neg_Apertura

    Public c_Neg_Asientos_Cab As New Neg_Asientos_Cab
    Public c_Neg_Asientos_Det As New Neg_Asientos_Det
    Public c_Neg_Asientos_Anexos As New Neg_Asientos_Anexos

    Public c_Neg_AlmTransforCab As New Neg_AlmTransforCab : Public c_Neg_AlmTransforDet As New Neg_AlmTransforDet

    Public c_Neg_MnSeriesGuias As New Neg_MnSeriesGuias
    Public c_Neg_MnMonedas As New Neg_MnMonedas
    Public c_Neg_MnTurno As New Neg_MnTurno
    Public c_Neg_MnEmprServ As New Neg_MnEmpServ
    Public c_Neg_MnTransporte As New Neg_MnTransporte
    '--> Ingreso de Tela Cruda <--'
    Public c_Neg_IngAlmIQ As New Neg_IngAlmIQ : Public c_Neg_IngAlmIQDet As New Neg_IngAlmIQDet
    Public c_Neg_RptStockIQ As New Neg_RptStockIQ
    Public c_Neg_MnAlmacen As New Neg_MnAlmacen
    Public c_Neg_MnTpoDoc As New Neg_MnTpoDoc
    Public c_Ent_MnTpoPago As New Neg_MnTpoPago
    Public c_Ent_MnEmpServ As New Ent_MnEmpServ

    Public c_Ent_MnTransporte As New Ent_MnTransporte

    Public c_Ent_Cliente As New Ent_MnCliente
    Public c_Ent_MnClienteOfi As New Ent_MnClienteOfi
    Public c_Ent_Mnigv As New Ent_MnIgv
    Public c_Ent_MnVendedor As New Ent_MnVendedor
    Public c_Ent_MnChofer As New Ent_MnChofer
    Public c_Ent_SeriesDoc As New Ent_MnSeriesDoc
    Public c_Ent_MnSeriesGuia As New Ent_MnSeriesGuia
    Public c_Ent_TpoCambio As New Ent_TpoCambio
    Public c_Ent_MnClienteServ As New Ent_MnClienteArt
    Public c_Ent_FactCab As New Ent_FactCab : Public c_Ent_FactDet As New Ent_FactDet : Public c_Ent_FactGuia As New Ent_FactGuia
    Public c_Ent_FactAnexo As New Ent_FactAnexo
    Public c_Ent_FactCuota As New Ent_FactCuota

    Public c_Ent_BolCab As New Ent_BolCab : Public c_Ent_BolDet As New Ent_BolDet : Public c_Ent_BolGuia As New Ent_BolGuia
    Public c_Ent_BolAnexo As New Ent_BolAnexo

    Public c_Ent_NotaC As New Ent_NotaC
    Public c_Ent_NotaD As New Ent_NotaD
    Public c_Ent_Liquidac As New Ent_Liquidac
    Public c_Ent_LetCab As New Ent_LetCab : Public c_Ent_LetDet As New Ent_LetDet
    Public c_Ent_RetenCab As New Ent_RetenCab : Public c_Ent_RetenDet As New Ent_RetenDet
    Public c_Ent_Apertura As New Ent_Apertura
    Public c_Ent_ComisDocs As New Ent_ComisDocs
    Public c_Ent_AlmTransforDet As New Ent_AlmTransforDet

    Public c_Ent_ComisCab As New Ent_ComisCab : Public c_Ent_ComisDet As New Ent_ComisDet
    Public c_Ent_Usuario As New Ent_Usuario
    Public c_Ent_AlmSalTa As New Ent_AlmSalTa : Public c_Ent_AlmSalTaDet As New Ent_AlmSalTaDet
    Public c_Ent_AlmSalAnexo As New Ent_AlmSalTaAnexo

    Public c_Ent_MnMtMov As New Ent_MnMtMov
    Public c_Ent_Usuarios As New Ent_Usuario
    Public c_Ent_UsuaPermiso As New Ent_UsuaPermiso

End Module
