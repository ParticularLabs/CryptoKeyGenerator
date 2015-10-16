# CryptoKeyGenerator
Small tool to easily generate a random 256 bit password in hex, base64 and ascii extended format

Just run the commandline tool and it will generate a new key and display it in several common formats.

## Usage

cryptokeygen.exe (options) (key in extended ascii)

    -s    Strip control characters (bytes 0-33) by incrementing these with 33.
    
    -7    Strip the 8th bit to make the text ASCII compatible.

## Output

Shows the (generated) key in Base64, Hex, ASCII (7bit) and extended ASCII.

The keygen generates a 256 bit key (32 bytes). Each formatted value has a scale to easily identify each DWORD (32 bits).

```
Strip 8th bit: True
Strip control: True
Key bit length: 256

Base64:
        KzpSTk1pezg5eTJRNmhWJmoxdFo6UDk2WlhaOyQ5N0U=
        |---------||---------||---------||---------|

Hex:
        2b3a524e4d697b3839793251366856266a31745a3a5039365a585a3b24393745
        |--------------||--------------||--------------||--------------|

ASCII:
        +:RNMi{89y2Q6hV&j1tZ:P96ZXZ;$97E     xml escape: +:RNMi{89y2Q6hV&amp;j1tZ:P96ZXZ;$97E
        |------||------||------||------|

ASCII-EX:
        +:RNMi{89y2Q6hV&j1tZ:P96ZXZ;$97E     xml escape: +:RNMi{89y2Q6hV&amp;j1tZ:P96ZXZ;$97E
        |------||------||------||------|
```
