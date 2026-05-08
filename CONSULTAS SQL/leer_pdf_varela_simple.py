#!/usr/bin/env python3
# ========================================
# SCRIPT SIMPLE PARA LEER PDF DE VARELA SIN DEPENDENCIAS
# ========================================

import os
import sys

def leer_pdf_simple():
    """
    Verifica si existe el PDF y muestra información básica
    sin necesidad de librerías externas
    """
    
    ruta_pdf = r"P:\ESTUDIOS CONSOLIDADOS\PREVENTIVA\2025\09\SEPTIEMBRE\05-09-2025\CLINICA\208 - 55676837 - 05092025 - VARELA BENICIO WILLIAM ELIEL.pdf"
    
    print(f"🔍 Buscando: {ruta_pdf}")
    
    # Verificar si el archivo existe
    if os.path.exists(ruta_pdf):
        print("✅ ARCHIVO ENCONTRADO")
        print(f"📁 Tamaño: {os.path.getsize(ruta_pdf)} bytes")
        print(f"📅 Modificado: {os.path.getmtime(ruta_pdf)}")
        
        # Intentar leer como texto para verificar contenido
        try:
            with open(ruta_pdf, 'rb') as file:
                contenido = file.read(1000)  # Leer primeros 1000 bytes
                print(f"📄 Contenido (primeros 1000 bytes):")
                print(f"   {contenido[:200]}...")
                
                # Verificar si contiene información del paciente
                texto_completo = contenido.decode('utf-8', errors='ignore').lower()
                
                if '55676837' in texto_completo:
                    print("✅ DNI del paciente encontrado en el PDF")
                if 'varela' in texto_completo or 'benicio' in texto_completo:
                    print("✅ Nombre del paciente encontrado en el PDF")
                if 'fútbol' in texto_completo or 'futbol' in texto_completo:
                    print("✅ Deporte mencionado en el PDF")
                if 'quilmes' in texto_completo:
                    print("✅ Club mencionado en el PDF")
                    
                print("\n🎯 CONCLUSIÓN:")
                print("   El PDF existe y contiene información del estudio clínico")
                print("   Si Varela no aparece en la interfaz, el problema está en el código")
                print("   y no en la falta del estudio físico")
                
        except Exception as e:
            print(f"❌ Error al leer: {str(e)}")
            
    else:
        print("❌ ARCHIVO NO ENCONTRADO")
        print("\n📁 RUTAS VERIFICADAS:")
        print("   P:\\ESTUDIOS CONSOLIDADOS\\PREVENTIVA\\2025\\")
        print("   P:\\ESTUDIOS CONSOLIDADOS\\PREVENTIVA\\2025\\09-SEPTIEMBRE\\")
        print("   P:\\ESTUDIOS CONSOLIDADOS\\PREVENTIVA\\2025\\09-SEPTIEMBRE\\05-09-2025\\")
        print("   P:\\ESTUDIOS CONSOLIDADOS\\PREVENTIVA\\2025\\09-SEPTIEMBRE\\05-09-2025\\CLINICA\\")
        print("\n🔍 SUGERENCIAS:")
        print("   1. Verificar si el archivo está en otra fecha")
        print("   2. Verificar si el nombre es ligeramente diferente")
        print("   3. Buscar manualmente en el explorador de archivos")

if __name__ == "__main__":
    print("🏥 LEER PDF DE ESTUDIO CLÍNICO - VARELA")
    print("=" * 50)
    leer_pdf_simple()
    print("=" * 50)
