// Replica exacta del algoritmo de encriptar/desencriptar de Comunes.Utilidades (C#)
// Cada carácter se invierte y se le suma 3 al código ASCII, luego se convierte a hex

function encriptar(cadena) {
    let nueva = '';
    for (let i = cadena.length - 1; i >= 0; i--) {
        const charCode = cadena.charCodeAt(i) + 3;
        nueva += charCode.toString(16);
    }
    return nueva;
}

function desencriptar(cadena) {
    let nueva = '';
    for (let i = cadena.length - 1; i >= 0; i--) {
        i--;
        const hex = cadena.substring(i, i + 2);
        const charCode = parseInt(hex, 16) - 3;
        nueva += String.fromCharCode(charCode);
    }
    return nueva;
}

module.exports = { encriptar, desencriptar };
