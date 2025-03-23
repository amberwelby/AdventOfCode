// Day 1: Not Quite Lisp 
// https://adventofcode.com/2015/day/1
// 2025/03/23

// Different approach (without giant arbitrary buffer)

#include <stdio.h>

int main(int argc, char *argv[]){
    // Start on ground floor
    int floor = 0;
    // Index of direction when we first enter the basement
    int basement = 0;
    int numDirections = 0;
    char direction;

    // If no filename arg was passed, exit
    if(argc < 2){
        return -1;
    }

    // Read in input from file
    FILE *fptr;
    char *filename = argv[1];
    fptr = fopen(filename, "r");

    // Iterate through directions in file
    while((direction = fgetc(fptr) )!= EOF){
        numDirections++;
        if(direction == '('){
            floor++;
        }
        else if(direction ==  ')'){
            floor--;
        }
        // Check for first time entering basement 
        if(floor == -1 && basement == 0){
            basement = numDirections;
        }
    }

    fclose(fptr);
    
    printf("Destination: %d\n", floor);
    printf("First enter basement: %d\n", basement);

    return 0;
}