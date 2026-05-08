#!/usr/bin/env python3
# ========================================
# SCRIPT PARA LEER PDF DE ESTUDIO CLÍNICO DE VARELA
# ========================================

import PyPDF2
import sys
import os

def leer_pdf_varela():
    """
    Lee el contenido del PDF del estudio clínico de Varela
    y extrae información relevante para el diagnóstico
    """
    
    ruta_pdf = r"P:\ESTUDIOS CONSOLIDADOS\PREVENTIVA\2025\09\SEPTIEMBRE\05-09-2025\CLINICA\208 - 55676837 - 05092025 - VARELA BENICIO WILLIAM ELIEL.pdf"
    
    print(f"Buscando archivo: {ruta_pdf}")
    
    # Verificar si el archivo existe
    if not os.path.exists(ruta_pdf):
        print("❌ ERROR: El archivo PDF no existe en la ruta especificada")
        print("📁 Ruta verificada:")
        print("   P:\\ESTUDIOS CONSOLIDADOS\\PREVENTIVA\\2025\\")
        print("   📁 Septiembre:")
        print("   📁 05-09-2025:")
        print("   📁 CLINICA:")
        print("   📄 208 - 55676837 - 05092025 - VARELA BENICIO WILLIAM ELIEL.pdf")
        return False
    
    try:
        # Leer el PDF
        print("📖 Leyendo contenido del PDF...")
        with open(ruta_pdf, 'rb') as file:
            reader = PyPDF2.PdfReader(file)
            
            print(f"✅ PDF encontrado con {len(reader.pages)} páginas")
            
            # Extraer información básica
            info = {
                'titulo': reader.metadata.get('/Title', 'Sin título'),
                'autor': reader.metadata.get('/Author', 'Sin autor'),
                'creador': reader.metadata.get('/Creator', 'Sin creador'),
                'productor': reader.metadata.get('/Producer', 'Sin productor'),
                'paginas': len(reader.pages)
            }
            
            print("\n📋 INFORMACIÓN DEL DOCUMENTO:")
            for key, value in info.items():
                print(f"   {key}: {value}")
            
            # Buscar texto relevante en las primeras 3 páginas
            print("\n🔍 BUSCANDO INFORMACIÓN MÉDICA RELEVANTE...")
            texto_medico = ""
            
            for i, page in enumerate(reader.pages[:3]):  # Primeras 3 páginas
                try:
                    texto = page.extract_text()
                    if texto.strip():
                        texto_medico += texto + "\n"
                        print(f"   📄 Página {i+1}: Encontrados {len(texto.strip())} caracteres")
                except:
                    print(f"   ⚠️  Página {i+1}: No se pudo leer")
            
            # Buscar palabras clave médicas
            palabras_clave = [
                'paciente', 'dni', 'diagnóstico', 'examen', 'médico',
                'clinico', 'estudio', 'resultado', 'informe',
                'VARELA', 'BENICIO', 'WILLIAM', 'ELIEL',
                '55676837', 'fútbol', 'deporte', 'preventivo'
            ]
            
            print("\n🔍 PALABRAS CLAVE ENCONTRADAS:")
            palabras_encontradas = []
            for palabra in palabras_clave:
                if palabra.lower() in texto_medico.lower():
                    palabras_encontradas.append(palabra)
                    print(f"   ✅ {palabra}")
            
            # Buscar información específica del paciente
            print("\n👤 INFORMACIÓN DEL PACIENTE:")
            if '55676837' in texto_medico:
                print("   ✅ DNI: 55676837 encontrado")
            if 'VARELA' in texto_medico or 'BENICIO' in texto_medico:
                print("   ✅ Nombre: VARELA BENICIO encontrado")
            
            # Buscar información del examen
            print("\n🏥 INFORMACIÓN DEL EXAMEN:")
            if 'fútbol' in texto_medico.lower():
                print("   ✅ Deporte: Fútbol encontrado")
            if 'preventivo' in texto_medico.lower():
                print("   ✅ Tipo: Preventivo encontrado")
            
            # Análisis para el problema de interfaz
            print("\n🔍 ANÁLISIS PARA PROBLEMA DE INTERFAZ:")
            if len(palabras_encontradas) > 0:
                print("   ✅ PDF contiene información médica válida")
                print("   📊 El estudio debería aparecer en el sistema")
                print("   ❌ Si no aparece, el problema está en la interfaz o filtros")
            else:
                print("   ❌ PDF no contiene información médica reconocible")
                print("   📊 Puede que el estudio esté incompleto o mal formateado")
            
            return True
            
    except Exception as e:
        print(f"❌ ERROR al leer PDF: {str(e)}")
        return False

if __name__ == "__main__":
    print("🏥 LEER PDF DE ESTUDIO CLÍNICO - VARELA BENICIO")
    print("=" * 60)
    leer_pdf_varela()
    print("=" * 60)
