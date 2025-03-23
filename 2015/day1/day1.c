// Day 1: Not Quite Lisp 
// https://adventofcode.com/2015/day/1
// 2025/03/23

#include <stdio.h>

int main(int argc, char *argv[]){
    // There's no official max directions given
    int MAX_DIRECTIONS = 7001;
    // Start on ground floor
    int floor = 0;

    // If no filename arg was passed, exit
    if(argc < 2){
        return -1;
    }

    // Read in input from file
    FILE *fptr;
    char *filename = argv[1];
    fptr = fopen(filename, "r");
    char directions[MAX_DIRECTIONS];
    fgets(directions, MAX_DIRECTIONS, fptr);
    fclose(fptr);
    
    // Iterate through directions
    for(int i = 0; i < MAX_DIRECTIONS; i++){
        if(directions[i] == '('){
            floor++;
        }
        else if(directions[i] ==  ')'){
            floor--;
        }
    }

    printf("Destination: %d\n", floor);

    return 0;
}