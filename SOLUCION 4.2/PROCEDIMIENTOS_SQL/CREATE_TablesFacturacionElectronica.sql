-- ============================================================
-- TABLAS PARA FACTURACIÓN ELECTRÓNICA AFIP
-- Ejecutar en la base de datos de Mepryl
-- ============================================================

-- ── 1. Configuración AFIP (registro único, id=1) ──────────────
IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.ConfiguracionAFIP') AND type = 'U')
BEGIN
    CREATE TABLE dbo.ConfiguracionAFIP (
        id              INT          PRIMARY KEY DEFAULT 1,
        cuitEmisor      VARCHAR(13)  NOT NULL,
        razonSocial     VARCHAR(200) NOT NULL,
        condicionIVA    VARCHAR(50)  NOT NULL DEFAULT 'RI',   -- RI=Resp.Inscripto
        puntoVenta      INT          NOT NULL DEFAULT 1,
        ambiente        CHAR(1)      NOT NULL DEFAULT 'H',    -- H=Homologacion, P=Produccion
        rutaCertificado VARCHAR(500) NOT NULL,
        passwordCert    VARCHAR(200) NOT NULL DEFAULT '',
        domicilioEmisor VARCHAR(300) NOT NULL DEFAULT ''
    );
    PRINT 'Tabla dbo.ConfiguracionAFIP creada correctamente.';
END
ELSE
    PRINT 'Tabla dbo.ConfiguracionAFIP ya existe. No se realizaron cambios.';
GO

-- ── 2. Comprobantes electrónicos emitidos ─────────────────────
IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.FacturaElectronica') AND type = 'U')
BEGIN
    CREATE TABLE dbo.FacturaElectronica (
        id                   UNIQUEIDENTIFIER  PRIMARY KEY DEFAULT NEWID(),
        idTurno              UNIQUEIDENTIFIER  NOT NULL,
        tipoComprobante      INT           NOT NULL,          -- 1=FactA, 6=FactB, 11=FactC
        puntoVenta           INT           NOT NULL,
        nroComprobante       BIGINT        NOT NULL,
        cae                  VARCHAR(14)   NULL,
        fechaVencCAE         DATE          NULL,
        fechaEmision         DATE          NOT NULL DEFAULT GETDATE(),
        cuitReceptor         VARCHAR(13)   NOT NULL DEFAULT '0',
        nombreReceptor       VARCHAR(200)  NOT NULL DEFAULT '',
        condicionIVAReceptor VARCHAR(10)   NOT NULL DEFAULT 'CF',
        importeNeto          DECIMAL(18,2) NOT NULL DEFAULT 0,
        importeIVA           DECIMAL(18,2) NOT NULL DEFAULT 0,
        importeTotal         DECIMAL(18,2) NOT NULL DEFAULT 0,
        concepto             INT           NOT NULL DEFAULT 2, -- 1=Prod, 2=Serv, 3=P+S
        estado               VARCHAR(20)   NOT NULL DEFAULT 'Pendiente',
        observaciones        VARCHAR(500)  NULL,
        fechaCreacion        DATETIME      NOT NULL DEFAULT GETDATE()
    );

    -- Índices para búsquedas frecuentes
    CREATE INDEX IX_FacturaElectronica_idTurno
        ON dbo.FacturaElectronica (idTurno);

    CREATE INDEX IX_FacturaElectronica_tipoVenta
        ON dbo.FacturaElectronica (tipoComprobante, puntoVenta, nroComprobante);

    CREATE INDEX IX_FacturaElectronica_fechaEmision
        ON dbo.FacturaElectronica (fechaEmision);

    PRINT 'Tabla dbo.FacturaElectronica creada correctamente.';
END
ELSE
    PRINT 'Tabla dbo.FacturaElectronica ya existe. No se realizaron cambios.';
GO

-- ── 3. Fila inicial de configuración (completar con datos reales) ──
IF NOT EXISTS (SELECT 1 FROM dbo.ConfiguracionAFIP WHERE id = 1)
BEGIN
    INSERT INTO dbo.ConfiguracionAFIP
        (id, cuitEmisor, razonSocial, condicionIVA, puntoVenta, ambiente, rutaCertificado, passwordCert, domicilioEmisor)
    VALUES
        (1, '00-00000000-0', 'RAZON SOCIAL', 'RI', 1, 'H', '', '', '');
    PRINT 'Fila de configuración inicial insertada. Actualizar con datos reales.';
END
GO
