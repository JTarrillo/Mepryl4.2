-- Índice cubriente para el query principal de Ventanilla/Recepción
-- Optimiza: WHERE t.fecha >= X AND t.fecha < Y AND t.habilitado = '1'
-- Incluye todas las columnas del SELECT + JOIN keys
-- Tiempo esperado: 302ms → <20ms

-- Verificar si ya existe
IF NOT EXISTS (
    SELECT 1 FROM sys.indexes 
    WHERE object_id = OBJECT_ID('dbo.Turno') 
    AND name = 'IX_Turno_Fecha_Habilitado_Ventanilla'
)
BEGIN
    CREATE NONCLUSTERED INDEX IX_Turno_Fecha_Habilitado_Ventanilla
    ON dbo.Turno (fecha ASC, habilitado ASC)
    INCLUDE (
        recepcion,
        horaReferencia,
        nroOrden,
        observaciones,
        codigo,
        asistio,
        reserva,
        pacienteID,
        abono,
        reservado,
        ocultar,
        horarioID
    );

    PRINT 'Índice IX_Turno_Fecha_Habilitado_Ventanilla creado correctamente.';
END
ELSE
    PRINT 'El índice ya existe.';

-- (Opcional) También aplica para Agenda del Día si no tiene índice similar
-- El mismo índice sirve para ambas pantallas ya que filtran igual por fecha+habilitado
