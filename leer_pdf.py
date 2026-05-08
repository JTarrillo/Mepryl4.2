import PyPDF2
import sys

def leer_pdf(ruta_pdf):
    try:
        with open(ruta_pdf, 'rb') as archivo:
            lector = PyPDF2.PdfReader(archivo)
            print(f"El PDF tiene {len(lector.pages)} páginas")
            print("=" * 50)
            
            for num_pagina in range(len(lector.pages)):
                pagina = lector.pages[num_pagina]
                texto = pagina.extract_text()
                print(f"\n--- Página {num_pagina + 1} ---")
                print(texto)
                print("-" * 30)
                
    except FileNotFoundError:
        print(f"Error: No se encuentra el archivo en la ruta: {ruta_pdf}")
    except Exception as e:
        print(f"Error al leer el PDF: {str(e)}")

if __name__ == "__main__":
    ruta = r"p:\ESTUDIOS CONSOLIDADOS\PREVENTIVA\2025\09-SEPTIEMBRE\05-09-2025\CLINICA\208 - 55676837 - 05092025 - VARELA BENICIO WILLIAM ELIEL.pdf"
    leer_pdf(ruta)
