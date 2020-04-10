using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DES
{
    class des
    {
        private UInt64[] sub_key; // 48 bits each


        /**
         * Konstruktor
         */
        public des()
        {
            sub_key = new UInt64[16];
        }


        /**
         * Szyfrowanie 64 bitowego bloku danych
         */
        public UInt64 Encrypt(UInt64 data, UInt64 key)
        {
            // generowanie kluczy
            Keygen(key);
            // permutacja początkowa
            data = InitialPermutation(data);

            // podział danych na dwie części po 32 bity
            UInt32 R = (UInt32)data;  // prawa 32 bitowa część danych
            UInt32 L = (UInt32)(data>>32);  // lewa 32 bitowa część danych
            
            UInt32 L_prime = 0;
            // 16 rund szyfrowania
            for (byte i = 0; i < 16; i++)
            {
                L_prime = R;  // nowa lewa część danych
                R = L ^ f(R, sub_key[i]);  // nowa prawa część danych
                L = L_prime;
            }
            // łączenie części prawej i lewej
            data = (((UInt64)R) << 32) | (UInt64)L;
            // permutacja końcowa
            return FinalPermutation(data);
        }


        /**
         * Deszyfrowanie 64 bitowego bloku danych
         */
        public UInt64 Decrypt(UInt64 data, UInt64 key)
        {
            // generowanie kluczy
            Keygen(key);
            // permutacja początkowa
            data = InitialPermutation(data);

            // podział danych na dwie części po 32 bity
            UInt32 R = (UInt32)data;  // prawa 32 bitowa część danych
            UInt32 L = (UInt32)(data >> 32);  // lewa 32 bitowa część danych

            UInt32 L_prime = 0;
            // 16 rund szyfrowania
            for (byte i = 0; i < 16; i++)
            {
                L_prime = R;  // nowa lewa część danych
                R = L ^ f(R, sub_key[15-i]);  // nowa prawa część danych
                L = L_prime;
            }
            // łączenie części prawej i lewej
            data = (((UInt64)R) << 32) | (UInt64)L;
            // permutacja końcowa
            return FinalPermutation(data);
        }

        // Tabela permutacji początkowej
        private static readonly byte[] IP = new byte[64]
        {
            58, 50, 42, 34, 26, 18, 10, 2,
            60, 52, 44, 36, 28, 20, 12, 4,
            62, 54, 46, 38, 30, 22, 14, 6,
            64, 56, 48, 40, 32, 24, 16, 8,
            57, 49, 41, 33, 25, 17,  9, 1,
            59, 51, 43, 35, 27, 19, 11, 3,
            61, 53, 45, 37, 29, 21, 13, 5,
            63, 55, 47, 39, 31, 23, 15, 7
        };

        // Tabela permutacji PC-1
        private static readonly byte[] PC1 = new byte[56]
        {
            57, 49, 41, 33, 25, 17,  9,
             1, 58, 50, 42, 34, 26, 18,
            10,  2, 59, 51, 43, 35, 27,
            19, 11,  3, 60, 52, 44, 36,

            63, 55, 47, 39, 31, 23, 15,
             7, 62, 54, 46, 38, 30, 22,
            14,  6, 61, 53, 45, 37, 29,
            21, 13,  5, 28, 20, 12,  4
        };

        // Tabela permutacji rozszerzającej (E BIT-SELECTION TABLE)
        private static readonly byte[] EXPANSION = new byte[48]
        {
            32,  1,  2,  3,  4,  5,
             4,  5,  6,  7,  8,  9,
             8,  9, 10, 11, 12, 13,
            12, 13, 14, 15, 16, 17,
            16, 17, 18, 19, 20, 21,
            20, 21, 22, 23, 24, 25,
            24, 25, 26, 27, 28, 29,
            28, 29, 30, 31, 32,  1
        };

        // Tabela przesunięcia bitów klucza
        private static readonly byte[] ITERATION_SHIFT = new byte[16]
        {
            1,  1,  2,  2,  2,  2,  2,  2,  1,  2,  2,  2,  2,  2,  2,  1
        };

        // Tabela permutacji PC-2
        private static readonly byte[] PC2 = new byte[48]
        {
            14, 17, 11, 24,  1,  5,
             3, 28, 15,  6, 21, 10,
            23, 19, 12,  4, 26,  8,
            16,  7, 27, 20, 13,  2,
            41, 52, 31, 37, 47, 55,
            30, 40, 51, 45, 33, 48,
            44, 49, 39, 56, 34, 53,
            46, 42, 50, 36, 29, 32
        };

        // S-bloki [8*16*4]
        private static readonly byte[,] SBOX = new byte[,]
        {
            {  // S1
                14,  4, 13,  1,  2, 15, 11,  8,  3, 10,  6, 12,  5,  9,  0,  7,
                 0, 15,  7,  4, 14,  2, 13,  1, 10,  6, 12, 11,  9,  5,  3,  8,
                 4,  1, 14,  8, 13,  6,  2, 11, 15, 12,  9,  7,  3, 10,  5,  0,
                15, 12,  8,  2,  4,  9,  1,  7,  5, 11,  3, 14, 10,  0,  6, 13
            },
            {  // S2
                15,  1,  8, 14,  6, 11,  3,  4,  9,  7,  2, 13, 12,  0,  5, 10,
                 3, 13,  4,  7, 15,  2,  8, 14, 12,  0,  1, 10,  6,  9, 11,  5,
                 0, 14,  7, 11, 10,  4, 13,  1,  5,  8, 12,  6,  9,  3,  2, 15,
                13,  8, 10,  1,  3, 15,  4,  2, 11,  6,  7, 12,  0,  5, 14,  9
            },
            {  // S3
                10,  0,  9, 14,  6,  3, 15,  5,  1, 13, 12,  7, 11,  4,  2,  8,
                13,  7,  0,  9,  3,  4,  6, 10,  2,  8,  5, 14, 12, 11, 15,  1,
                13,  6,  4,  9,  8, 15,  3,  0, 11,  1,  2, 12,  5, 10, 14,  7,
                 1, 10, 13,  0,  6,  9,  8,  7,  4, 15, 14,  3, 11,  5,  2, 12
            },
            {  // S4
                 7, 13, 14,  3,  0,  6,  9, 10,  1,  2,  8,  5, 11, 12,  4, 15,
                13,  8, 11,  5,  6, 15,  0,  3,  4,  7,  2, 12,  1, 10, 14,  9,
                10,  6,  9,  0, 12, 11,  7, 13, 15,  1,  3, 14,  5,  2,  8,  4,
                 3, 15,  0,  6, 10,  1, 13,  8,  9,  4,  5, 11, 12,  7,  2, 14
            },
            {  // S5
                 2, 12,  4,  1,  7, 10, 11,  6,  8,  5,  3, 15, 13,  0, 14,  9,
                14, 11,  2, 12,  4,  7, 13,  1,  5,  0, 15, 10,  3,  9,  8,  6,
                 4,  2,  1, 11, 10, 13,  7,  8, 15,  9, 12,  5,  6,  3,  0, 14,
                11,  8, 12,  7,  1, 14,  2, 13,  6, 15,  0,  9, 10,  4,  5,  3
            },
            {  // S6
                12,  1, 10, 15,  9,  2,  6,  8,  0, 13,  3,  4, 14,  7,  5, 11,
                10, 15,  4,  2,  7, 12,  9,  5,  6,  1, 13, 14,  0, 11,  3,  8,
                 9, 14, 15,  5,  2,  8, 12,  3,  7,  0,  4, 10,  1, 13, 11,  6,
                 4,  3,  2, 12,  9,  5, 15, 10, 11, 14,  1,  7,  6,  0,  8, 13
            },
            {  // S7
                 4, 11,  2, 14, 15,  0,  8, 13,  3, 12,  9,  7,  5, 10,  6,  1,
                13,  0, 11,  7,  4,  9,  1, 10, 14,  3,  5, 12,  2, 15,  8,  6,
                 1,  4, 11, 13, 12,  3,  7, 14, 10, 15,  6,  8,  0,  5,  9,  2,
                 6, 11, 13,  8,  1,  4, 10,  7,  9,  5,  0, 15, 14,  2,  3, 12
            },
            {  // S8
                13,  2,  8,  4,  6, 15, 11,  1, 10,  9,  3, 14,  5,  0, 12,  7,
                 1, 15, 13,  8, 10,  3,  7,  4, 12,  5,  6, 11,  0, 14,  9,  2,
                 7, 11,  4,  1,  9, 12, 14,  2,  0,  6, 10, 13, 15,  3,  5,  8,
                 2,  1, 14,  7,  4, 10,  8, 13, 15, 12,  9,  0,  3,  5,  6, 11
            }
        };

        // Tabela permutacji w P-Bloku
        private static readonly byte[] PBOX = new byte[32]
        {
            16,  7, 20, 21,
            29, 12, 28, 17,
             1, 15, 23, 26,
             5, 18, 31, 10,
             2,  8, 24, 14,
            32, 27,  3,  9,
            19, 13, 30,  6,
            22, 11,  4, 25
        };

        // Tabela permutacji końcowej
        private static readonly byte[] FP = new byte[64]
        {
            40, 8, 48, 16, 56, 24, 64, 32,
            39, 7, 47, 15, 55, 23, 63, 31,
            38, 6, 46, 14, 54, 22, 62, 30,
            37, 5, 45, 13, 53, 21, 61, 29,
            36, 4, 44, 12, 52, 20, 60, 28,
            35, 3, 43, 11, 51, 19, 59, 27,
            34, 2, 42, 10, 50, 18, 58, 26,
            33, 1, 41,  9, 49, 17, 57, 25
        };


        /**
         * Generowanie bitów klucza.
         * KS, called the key schedule
         */
        private void Keygen(UInt64 key)
        {
            // zerowanie tabeli
            Array.Clear(sub_key, 0, sub_key.Length);

            UInt64 permuted_choice_1 = 0;
            for (byte i = 0; i < 56; i++)  // 56 bitów klucza
            {
                permuted_choice_1 <<= 1;
                permuted_choice_1 |= (key >> (64 - PC1[i])) & 0x0000000000000001;  // permutacja PC-1
            }

            UInt32 C = (UInt32)((permuted_choice_1 >> 28) & 0x000000000fffffff);  // lewa połowa (28 bitów)
            UInt32 D = (UInt32)(permuted_choice_1 & 0x000000000fffffff);  // prawa połowa (28 bitów)

            // obliczanie 16 kluczy
            for (byte i = 0; i < 16; i++)
            {
                // przesuwanie Ci i Di
                for (byte j = 0; j < ITERATION_SHIFT[i]; j++)
                {
                    C = (0x0fffffff & (C << 1)) | (0x00000001 & (C >> 27));
                    D = (0x0fffffff & (D << 1)) | (0x00000001 & (D >> 27));
                }

                UInt64 permuted_choice_2 = (((UInt64)C) << 28) | (UInt64)D;
                sub_key[i] = 0; // każdy podklucz składa się z 48 bitów
                for (byte j = 0; j < 48; j++)
                {
                    sub_key[i] <<= 1;
                    sub_key[i] |= (permuted_choice_2 >> (56 - PC2[j])) & 0x0000000000000001;  // permutacja PC-2
                }
            }
        }


        /**
         * Permutacja początkowa.
         * Przyjmuje na wejście liczbę 64 bitową.
         * Zwraca liczbę 64 bitową.
         */
        private UInt64 InitialPermutation(UInt64 input)
        {
            UInt64 result = 0;  // wynik
            for (byte i = 0; i < 64; i++)  // iteracja po wszystkich bitach
            {
                result <<= 1;  // przesunięcie bitowe o 1 w lewo
                // zmiana pozycji bitu zgodnie z tablicą permutacji początkowej
                result |= (input >> (64 - IP[i])) & 0x0000000000000001;
            }
            return result;
        }

        /**
         * Funkcja f.
         * Przyjmuje 32 bity danych wejściowych i
         * 48 bitowy podklucz
         * Zwraca liczbę 32 bitową.
         */
        private UInt32 f(UInt32 R, UInt64 K)
        {
            UInt64 expanded_input = 0;
            // rozszerzenie z 32 bitów do 48 bitów
            for (byte i = 0; i < 48; i++)
            {
                expanded_input <<= 1;
                expanded_input |= (UInt64)((R >> (32 - EXPANSION[i])) & 0x00000001);
            }

            // XOR z podkluczem
            expanded_input ^= K;

            // S1(B1)S2(B2)S3(B3)S4(B4)S5(B5)S6(B6)S7(B7)S8(B8)
            UInt32 output_s = 0;
            // 8 s-bloków
            for (byte i = 0; i < 8; i++)
            {
                // wybranie pierwszego i ostatniego bitu z każdej 6 bitowej części
                byte row = (byte)((expanded_input & (UInt64)(0x0000840000000000 >> 6 * i)) >> (42 - 6 * i));
                row = (byte)((row >> 4) | (row & 0x01));

                // wybranie 4 środkowych bitów
                byte column = (byte)((expanded_input & (UInt64)(0x0000780000000000 >> 6 * i)) >> (43 - 6 * i));

                output_s <<= 4;  // przezsunięcie o 4 pozycje
                output_s |= (UInt32)(SBOX[i, 16 * row + column] & 0x0f);  // dodanie 4 bitów wyjściowych
            }
            
            UInt32 output_p = 0;
            // permutacja w P-blokach
            for (byte i = 0; i < 32; i++)
            {
                output_p <<= 1;
                output_p |= (output_s >> (32 - PBOX[i])) & 0x00000001;
            }

            return output_p;
        }


        /**
        * Permutacja końcowa.
         * Przyjmuje na wejście liczbę 64 bitową.
         * Zwraca liczbę 64 bitową.
         */
        private UInt64 FinalPermutation(UInt64 input)
        {
            UInt64 result = 0;
            for (byte i = 0; i < 64; i++)
            {
                result <<= 1;
                result |= (input >> (64 - FP[i])) & 0x0000000000000001;
            }
            return result;
        }
    }
}
