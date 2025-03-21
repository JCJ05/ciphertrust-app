using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ciphertrust_app.Definition
{
    internal class Definition
    {
        public const string CT_USERNAME = "desarrollo";
        public const string CT_PASSWORD = "Pcenterpwd1*";
    
        // Identificador de la clave simétrica para la encriptación
        public const string CT_AES_KEYNAME = "ct_aes_256_004";
        // Parámetros de encriptación simétrica
        public const string CT_AES_MECHANISM = "AES/CBC/PKCS5Padding";
        // Vector de inicialización para la encriptación simétrica en modo CBC
        public const string CT_AES_INITVECTOR = "3ABBE543B526F36290658A066F6CA619";
    
    
        // Identificador de la clave simétrica para la encriptación externa
        public const string CT_AES_KEYNAME_EXP = "ct_aes_256_003";
        // Parámetros de encriptación simétrica
        public const string CT_AES_MECHANISM_EXP = "AES/CBC/PKCS5Padding";
        // Vector de inicialización para la encriptación simétrica en modo CBC
        public const string CT_AES_INITVECTOR_EXP = "00000000000000000000000000000000";
    }
}
