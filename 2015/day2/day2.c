// Day 2: I Was Told There Would Be No Math
// https://adventofcode.com/2015/day/2
// 2025/03/29 (and then took a month hiatus to stop overengineering it)

#include <stdio.h>

int main(){
    // Open file
    FILE *fptr;
    fptr = fopen("day2-input.txt", "r");
    
    char *dimensions = NULL;
    int length = -1;
    int width = -1;
    int height = -1;
    int slack = -1;
    int total = 0;
    __ssize_t lineSize = 9;

    // For each present
    while(getline(&dimensions, &lineSize, fptr) != EOF){
        // Parse line into values
        sscanf(dimensions, "%dx%dx%d", &length, &width, &height);
        // printf("%s\nLength: %d\nWidth: %d\nHeight: %d\n\n", dimensions, length, width, height);

        // Calculate sides
        int lenWid = 2 * length * width;
        int widHei = 2 * width * height;
        int heiLen = 2 * height * length;
    
        // Calculate slack (+1 of smallest side)
        if(lenWid <= widHei && lenWid <= heiLen){
            slack = lenWid / 2;
        }
        else if(widHei <= lenWid && widHei <= heiLen){
            slack = widHei / 2;
        }
        else if (heiLen <= widHei && heiLen <= lenWid){
            slack = heiLen / 2;
        }
        else{
            printf("Error\n");
        }

        // Update total
        total = total + (lenWid + widHei + heiLen + slack);        
    }

    printf("Total wrapping paper required: %d square feet\n", total);

    return 0;
}