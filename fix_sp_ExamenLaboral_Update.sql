-- Stored procedure corregido para no sobrescribir campos con valores null
-- Solo actualiza campos que no son null

ALTER PROCEDURE [dbo].[sp_ExamenLaboral_Update]
                                                                                                                                                                                                             
@id uniqueidentifier,
                                                                                                                                                                                                                                        
@antCli varchar(300) = NULL, @antQui varchar(300) = NULL, @antTrau varchar(300) = NULL, @talla varchar(5) = NULL,
                                                                                                                                                                        
@peso varchar(5) = NULL, @entradaAire varchar(150) = NULL, @ruidosAgre varchar(150) = NULL, @ruidosCard varchar(150) = NULL,
                                                                                                                                                             
@silencios varchar(150) = NULL, @taMax varchar(3) = NULL, @taMin varchar(3) = NULL, @pulso varchar(2) = NULL,
                                                                                                                                                                            
@abdomen varchar(150) = NULL, @hernias varchar(150) = NULL, @varices varchar(150) = NULL, @apGenitour varchar(150) = NULL,
                                                                                                                                                                
@pielYFaneras varchar(150) = NULL, @apLocomotor varchar(150) = NULL, @snc varchar(150) = NULL, @ojoDer varchar(50) = NULL,
                                                                                                                                                                
@ojoDerLent varchar(50) = NULL, @ojoIzq varchar(50) = NULL, @ojoIzqLent varchar(50) = NULL, @visionCromatica varchar(150) = NULL,
                                                                                                                                                        
@exOdonto varchar(150) = NULL, @equil varchar(150) = NULL, @observacionesCli varchar(500) = NULL, @medico varchar(100) = NULL,
                                                                                                                                                            
@dictamenCli varchar(100) = NULL, @gRojos varchar(10) = NULL, @gBlancos varchar(10) = NULL, @hemoglobina varchar(5) = NULL,
                                                                                                                                                               
@hematocrito varchar(5) = NULL, @eritro varchar(5) = NULL, @plaquetas varchar(10) = NULL, @obsSerieRoja varchar(100) = NULL,
                                                                                                                                                             
@cayado varchar(2) = NULL, @segmentado varchar(2) = NULL, @eosinof varchar(2) = NULL, @basof varchar(2) = NULL,
                                                                                                                                                                          
@linfoc varchar(2) = NULL, @monoc varchar(2) = NULL, @obsSerieBlanca varchar(100) = NULL, @glucemia varchar(3) = NULL,
                                                                                                                                                                    
@uremia varchar(2) = NULL, @chagas varchar(50) = NULL, @vdrl varchar(50) = NULL, @grupo varchar(2) = NULL, @factor varchar(2) = NULL,
                                                                                                                                                            
@uricemia varchar(2) = NULL, @te varchar(3) = NULL, @otrosQuimicaHemat varchar(150) = NULL, @colTotal varchar(4) = NULL,
                                                                                                                                                                 
@hdl varchar(4) = NULL, @ldl varchar(4) = NULL, @trig varchar(4) = NULL, @otrosPerfilLipidico varchar(150) = NULL,
                                                                                                                                                                       
@color varchar(20) = NULL, @aspecto varchar(20) = NULL, @densidad varchar(5) = NULL, @ph varchar(2) = NULL, @celulas varchar(50) = NULL,
                                                                                                                                                        
@leuco varchar(50) = NULL, @hematies varchar(50) = NULL, @prot varchar(50) = NULL, @gluc varchar(50) = NULL,
                                                                                                                                                                             
@hemogOrina varchar(50) = NULL, @cetonas varchar(50) = NULL, @bilirrubina varchar(50) = NULL, @otrosOrina varchar(200) = NULL,
                                                                                                                                                            
@observacionesLab varchar(200) = NULL, @dictamenLab varchar(100) = NULL, @toraxF varchar(100) = NULL, @lumbarF varchar(100) = NULL,
                                                                                                                                                       
@lumbarP varchar(100) = NULL, @cervicalF varchar(100) = NULL, @cervicalP varchar(100) = NULL, @fnp varchar(100) = NULL,
                                                                                                                                                                  
@mnp varchar(100) = NULL, @hombrosF varchar(100) = NULL, @rodillasF varchar(100) = NULL, @caderasF varchar(100) = NULL,
                                                                                                                                                                  
@tobillosF varchar(100) = NULL, @craneoFyP varchar(100) = NULL, @hombroF varchar(100) = NULL, @hombroVP varchar(100) = NULL,
                                                                                                                                                             
@humeroFyP varchar(100) = NULL, @codoFyP varchar(100) = NULL, @antebrazoFyP varchar(100) = NULL, @munecaFyP varchar(100) = NULL,
                                                                                                                                                         
@manoFyP varchar(100) = NULL, @toraxP varchar(100) = NULL, @pCostalFyO varchar(100) = NULL, @colDorsalFyP varchar(100) = NULL,
                                                                                                                                                           
@pelvisF varchar(100) = NULL, @caderaF varchar(100) = NULL, @caderaP varchar(100) = NULL, @femurFyP varchar(100) = NULL,
                                                                                                                                                                 
@rodillaF varchar(100) = NULL, @rodillaP varchar(100) = NULL, @piernaFyP varchar(100) = NULL, @tobilloFyP varchar(100) = NULL,
                                                                                                                                                            
@axialDeCalcaneo varchar(100) = NULL, @pieFyP varchar(100) = NULL, @audio varchar(150) = NULL, @ergo varchar(150) = NULL,
                                                                                                                                                                 
@eco varchar(150) = NULL, @psico varchar(150) = NULL, @espiro varchar(150) = NULL, @eeg varchar(150) = NULL, @iTorg varchar(150) = NULL,
                                                                                                                                                        
@ecg varchar(150) = NULL, @observaciones varchar(400) = NULL, @dictamen varchar(100) = NULL, @na VARCHAR(5) = NULL, @k VARCHAR(5) = NULL,
                                                                                                                                                        
@protTotal VARCHAR(5) = NULL, @albumina VARCHAR(5) = NULL, @alfa1 VARCHAR(5) = NULL, @alfa2 VARCHAR(5) = NULL, @beta1 VARCHAR(5) = NULL,
                                                                                                                                                        
@beta2 VARCHAR(5) = NULL, @gammaglob VARCHAR(5) = NULL, @relacAlbGlob VARCHAR(5) = NULL, @creat VARCHAR(5) = NULL,
                                                                                                                                                                       
@dorsalF NVARCHAR(MAX) = NULL,
                                                                                                                                                                                                                               
@espinogramaP NVARCHAR(MAX) = NULL
                                                                                                                                                                                                                           
AS
                                                                                                                                                                                                                                                           
UPDATE dbo.ExamenLaboral
                                                                                                                                                                                                                                     
SET antCli = CASE WHEN @antCli IS NULL THEN antCli ELSE @antCli END,
    antQui = CASE WHEN @antQui IS NULL THEN antQui ELSE @antQui END,
    antTrau = CASE WHEN @antTrau IS NULL THEN antTrau ELSE @antTrau END,
    talla = CASE WHEN @talla IS NULL THEN talla ELSE @talla END,
    peso = CASE WHEN @peso IS NULL THEN peso ELSE @peso END,
    entradaAire = CASE WHEN @entradaAire IS NULL THEN entradaAire ELSE @entradaAire END,
    ruidosAgre = CASE WHEN @ruidosAgre IS NULL THEN ruidosAgre ELSE @ruidosAgre END,
    ruidosCard = CASE WHEN @ruidosCard IS NULL THEN ruidosCard ELSE @ruidosCard END,
    silencios = CASE WHEN @silencios IS NULL THEN silencios ELSE @silencios END,
    taMax = CASE WHEN @taMax IS NULL THEN taMax ELSE @taMax END,
    taMin = CASE WHEN @taMin IS NULL THEN taMin ELSE @taMin END,
    pulso = CASE WHEN @pulso IS NULL THEN pulso ELSE @pulso END,
    abdomen = CASE WHEN @abdomen IS NULL THEN abdomen ELSE @abdomen END,
    hernias = CASE WHEN @hernias IS NULL THEN hernias ELSE @hernias END,
    varices = CASE WHEN @varices IS NULL THEN varices ELSE @varices END,
    apGenitour = CASE WHEN @apGenitour IS NULL THEN apGenitour ELSE @apGenitour END,
    pielYFaneras = CASE WHEN @pielYFaneras IS NULL THEN pielYFaneras ELSE @pielYFaneras END,
    apLocomotor = CASE WHEN @apLocomotor IS NULL THEN apLocomotor ELSE @apLocomotor END,
    snc = CASE WHEN @snc IS NULL THEN snc ELSE @snc END,
    ojoDer = CASE WHEN @ojoDer IS NULL THEN ojoDer ELSE @ojoDer END,
    ojoDerLent = CASE WHEN @ojoDerLent IS NULL THEN ojoDerLent ELSE @ojoDerLent END,
    ojoIzq = CASE WHEN @ojoIzq IS NULL THEN ojoIzq ELSE @ojoIzq END,
    ojoIzqLent = CASE WHEN @ojoIzqLent IS NULL THEN ojoIzqLent ELSE @ojoIzqLent END,
    visionCromatica = CASE WHEN @visionCromatica IS NULL THEN visionCromatica ELSE @visionCromatica END,
    exOdonto = CASE WHEN @exOdonto IS NULL THEN exOdonto ELSE @exOdonto END,
    equil = CASE WHEN @equil IS NULL THEN equil ELSE @equil END,
    observacionesCli = CASE WHEN @observacionesCli IS NULL THEN observacionesCli ELSE @observacionesCli END,
    medico = CASE WHEN @medico IS NULL THEN medico ELSE @medico END,
    dictamenCli = CASE WHEN @dictamenCli IS NULL THEN dictamenCli ELSE @dictamenCli END,
    gRojos = CASE WHEN @gRojos IS NULL THEN gRojos ELSE @gRojos END,
    gBlancos = CASE WHEN @gBlancos IS NULL THEN gBlancos ELSE @gBlancos END,
    hemoglobina = CASE WHEN @hemoglobina IS NULL THEN hemoglobina ELSE @hemoglobina END,
    hematocrito = CASE WHEN @hematocrito IS NULL THEN hematocrito ELSE @hematocrito END,
    eritro = CASE WHEN @eritro IS NULL THEN eritro ELSE @eritro END,
    plaquetas = CASE WHEN @plaquetas IS NULL THEN plaquetas ELSE @plaquetas END,
    obsSerieRoja = CASE WHEN @obsSerieRoja IS NULL THEN obsSerieRoja ELSE @obsSerieRoja END,
    cayado = CASE WHEN @cayado IS NULL THEN cayado ELSE @cayado END,
    segmentado = CASE WHEN @segmentado IS NULL THEN segmentado ELSE @segmentado END,
    eosinof = CASE WHEN @eosinof IS NULL THEN eosinof ELSE @eosinof END,
    basof = CASE WHEN @basof IS NULL THEN basof ELSE @basof END,
    linfoc = CASE WHEN @linfoc IS NULL THEN linfoc ELSE @linfoc END,
    monoc = CASE WHEN @monoc IS NULL THEN monoc ELSE @monoc END,
    obsSerieBlanca = CASE WHEN @obsSerieBlanca IS NULL THEN obsSerieBlanca ELSE @obsSerieBlanca END,
    glucemia = CASE WHEN @glucemia IS NULL THEN glucemia ELSE @glucemia END,
    uremia = CASE WHEN @uremia IS NULL THEN uremia ELSE @uremia END,
    chagas = CASE WHEN @chagas IS NULL THEN chagas ELSE @chagas END,
    vdrl = CASE WHEN @vdrl IS NULL THEN vdrl ELSE @vdrl END,
    grupo = CASE WHEN @grupo IS NULL THEN grupo ELSE @grupo END,
    factor = CASE WHEN @factor IS NULL THEN factor ELSE @factor END,
    uricemia = CASE WHEN @uricemia IS NULL THEN uricemia ELSE @uricemia END,
    te = CASE WHEN @te IS NULL THEN te ELSE @te END,
    otrosQuimicaHemat = CASE WHEN @otrosQuimicaHemat IS NULL THEN otrosQuimicaHemat ELSE @otrosQuimicaHemat END,
    colTotal = CASE WHEN @colTotal IS NULL THEN colTotal ELSE @colTotal END,
    hdl = CASE WHEN @hdl IS NULL THEN hdl ELSE @hdl END,
    ldl = CASE WHEN @ldl IS NULL THEN ldl ELSE @ldl END,
    trig = CASE WHEN @trig IS NULL THEN trig ELSE @trig END,
    otrosPerfilLipidico = CASE WHEN @otrosPerfilLipidico IS NULL THEN otrosPerfilLipidico ELSE @otrosPerfilLipidico END,
    color = CASE WHEN @color IS NULL THEN color ELSE @color END,
    aspecto = CASE WHEN @aspecto IS NULL THEN aspecto ELSE @aspecto END,
    densidad = CASE WHEN @densidad IS NULL THEN densidad ELSE @densidad END,
    ph = CASE WHEN @ph IS NULL THEN ph ELSE @ph END,
    celulas = CASE WHEN @celulas IS NULL THEN celulas ELSE @celulas END,
    leuco = CASE WHEN @leuco IS NULL THEN leuco ELSE @leuco END,
    hematies = CASE WHEN @hematies IS NULL THEN hematies ELSE @hematies END,
    prot = CASE WHEN @prot IS NULL THEN prot ELSE @prot END,
    gluc = CASE WHEN @gluc IS NULL THEN gluc ELSE @gluc END,
    hemogOrina = CASE WHEN @hemogOrina IS NULL THEN hemogOrina ELSE @hemogOrina END,
    cetonas = CASE WHEN @cetonas IS NULL THEN cetonas ELSE @cetonas END,
    bilirrubina = CASE WHEN @bilirrubina IS NULL THEN bilirrubina ELSE @bilirrubina END,
    otrosOrina = CASE WHEN @otrosOrina IS NULL THEN otrosOrina ELSE @otrosOrina END,
    observacionesLab = CASE WHEN @observacionesLab IS NULL THEN observacionesLab ELSE @observacionesLab END,
    dictamenLab = CASE WHEN @dictamenLab IS NULL THEN dictamenLab ELSE @dictamenLab END,
    toraxF = CASE WHEN @toraxF IS NULL THEN toraxF ELSE @toraxF END,
    lumbarF = CASE WHEN @lumbarF IS NULL THEN lumbarF ELSE @lumbarF END,
    lumbarP = CASE WHEN @lumbarP IS NULL THEN lumbarP ELSE @lumbarP END,
    cervicalF = CASE WHEN @cervicalF IS NULL THEN cervicalF ELSE @cervicalF END,
    cervicalP = CASE WHEN @cervicalP IS NULL THEN cervicalP ELSE @cervicalP END,
    fnp = CASE WHEN @fnp IS NULL THEN fnp ELSE @fnp END,
    mnp = CASE WHEN @mnp IS NULL THEN mnp ELSE @mnp END,
    hombrosF = CASE WHEN @hombrosF IS NULL THEN hombrosF ELSE @hombrosF END,
    rodillasF = CASE WHEN @rodillasF IS NULL THEN rodillasF ELSE @rodillasF END,
    caderasF = CASE WHEN @caderasF IS NULL THEN caderasF ELSE @caderasF END,
    tobillosF = CASE WHEN @tobillosF IS NULL THEN tobillosF ELSE @tobillosF END,
    craneoFyP = CASE WHEN @craneoFyP IS NULL THEN craneoFyP ELSE @craneoFyP END,
    hombroF = CASE WHEN @hombroF IS NULL THEN hombroF ELSE @hombroF END,
    hombroVP = CASE WHEN @hombroVP IS NULL THEN hombroVP ELSE @hombroVP END,
    humeroFyP = CASE WHEN @humeroFyP IS NULL THEN humeroFyP ELSE @humeroFyP END,
    codoFyP = CASE WHEN @codoFyP IS NULL THEN codoFyP ELSE @codoFyP END,
    antebrazoFyP = CASE WHEN @antebrazoFyP IS NULL THEN antebrazoFyP ELSE @antebrazoFyP END,
    munecaFyP = CASE WHEN @munecaFyP IS NULL THEN munecaFyP ELSE @munecaFyP END,
    manoFyP = CASE WHEN @manoFyP IS NULL THEN manoFyP ELSE @manoFyP END,
    toraxP = CASE WHEN @toraxP IS NULL THEN toraxP ELSE @toraxP END,
    pCostalFyO = CASE WHEN @pCostalFyO IS NULL THEN pCostalFyO ELSE @pCostalFyO END,
    colDorsalFyP = CASE WHEN @colDorsalFyP IS NULL THEN colDorsalFyP ELSE @colDorsalFyP END,
    pelvisF = CASE WHEN @pelvisF IS NULL THEN pelvisF ELSE @pelvisF END,
    caderaF = CASE WHEN @caderaF IS NULL THEN caderaF ELSE @caderaF END,
    caderaP = CASE WHEN @caderaP IS NULL THEN caderaP ELSE @caderaP END,
    femurFyP = CASE WHEN @femurFyP IS NULL THEN femurFyP ELSE @femurFyP END,
    rodillaF = CASE WHEN @rodillaF IS NULL THEN rodillaF ELSE @rodillaF END,
    rodillaP = CASE WHEN @rodillaP IS NULL THEN rodillaP ELSE @rodillaP END,
    piernaFyP = CASE WHEN @piernaFyP IS NULL THEN piernaFyP ELSE @piernaFyP END,
    tobilloFyP = CASE WHEN @tobilloFyP IS NULL THEN tobilloFyP ELSE @tobilloFyP END,
    axialDeCalcaneo = CASE WHEN @axialDeCalcaneo IS NULL THEN axialDeCalcaneo ELSE @axialDeCalcaneo END,
    pieFyP = CASE WHEN @pieFyP IS NULL THEN pieFyP ELSE @pieFyP END,
    audio = CASE WHEN @audio IS NULL THEN audio ELSE @audio END,
    ergo = CASE WHEN @ergo IS NULL THEN ergo ELSE @ergo END,
    eco = CASE WHEN @eco IS NULL THEN eco ELSE @eco END,
    psico = CASE WHEN @psico IS NULL THEN psico ELSE @psico END,
    espiro = CASE WHEN @espiro IS NULL THEN espiro ELSE @espiro END,
    eeg = CASE WHEN @eeg IS NULL THEN eeg ELSE @eeg END,
    iTorg = CASE WHEN @iTorg IS NULL THEN iTorg ELSE @iTorg END,
    ecg = CASE WHEN @ecg IS NULL THEN ecg ELSE @ecg END,
    observaciones = CASE WHEN @observaciones IS NULL THEN observaciones ELSE @observaciones END,
    dictamen = CASE WHEN @dictamen IS NULL THEN dictamen ELSE @dictamen END,
    na = CASE WHEN @na IS NULL THEN na ELSE @na END,
    k = CASE WHEN @k IS NULL THEN k ELSE @k END,
    protTotal = CASE WHEN @protTotal IS NULL THEN protTotal ELSE @protTotal END,
    albumina = CASE WHEN @albumina IS NULL THEN albumina ELSE @albumina END,
    alfa1 = CASE WHEN @alfa1 IS NULL THEN alfa1 ELSE @alfa1 END,
    alfa2 = CASE WHEN @alfa2 IS NULL THEN alfa2 ELSE @alfa2 END,
    beta1 = CASE WHEN @beta1 IS NULL THEN beta1 ELSE @beta1 END,
    beta2 = CASE WHEN @beta2 IS NULL THEN beta2 ELSE @beta2 END,
    gammaglob = CASE WHEN @gammaglob IS NULL THEN gammaglob ELSE @gammaglob END,
    relacAlbGlob = CASE WHEN @relacAlbGlob IS NULL THEN relacAlbGlob ELSE @relacAlbGlob END,
    creat = CASE WHEN @creat IS NULL THEN creat ELSE @creat END,
    dorsalF = CASE WHEN @dorsalF IS NULL THEN dorsalF ELSE @dorsalF END,
    espinogramaP = CASE WHEN @espinogramaP IS NULL THEN espinogramaP ELSE @espinogramaP END
                                                                                                                                                                                                                                   
WHERE id=@id
