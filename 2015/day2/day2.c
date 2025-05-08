// Day 2: I Was Told There Would Be No Math
// https://adventofcode.com/2015/day/2
// 2025/03/29 (and then took a month hiatus to stop overengineering it)

#include <stdio.h>

int main(){
    // Open file
    FILE *fptr;
    fptr = fopen("day2-input.txt", "r");
    
    // Initialize to dummy values
    char *dimensions = NULL;
    int length = -1;
    int width = -1;
    int height = -1;
    int slack = -1;
    int lenWid = -1;
    int widHei = -1;
    int heiLen = -1;
    int totalPaper = 0;
    int perimRibbon = -1;
    int volumeBow = -1;
    int totalRibbon = 0;
    // This is the max expected line length
    __ssize_t lineSize = 9;

    // For each present
    while(getline(&dimensions, &lineSize, fptr) != EOF){
        // Parse line into values
        sscanf(dimensions, "%dx%dx%d", &length, &width, &height);
        // printf("%s\nLength: %d\nWidth: %d\nHeight: %d\n\n", dimensions, length, width, height);

        // Calculate wrapping paper
        lenWid = 2 * length * width;
        widHei = 2 * width * height;
        heiLen = 2 * height * length;
    
        // Calculate slack (+1 of smallest side)
        if(lenWid <= widHei && lenWid <= heiLen){
            slack = lenWid / 2;
        }
        else if(widHei <= lenWid && widHei <= heiLen){
            slack = widHei / 2;
        }
        else if(heiLen <= widHei && heiLen <= lenWid){
            slack = heiLen / 2;
        }
        else{
            printf("Error calculating wrapping paper\n");
        }

        // Update total wrapping paper
        totalPaper = totalPaper + (lenWid + widHei + heiLen + slack);  
        
        // Calculate ribbon (perimeter of smallest side)
        if(length <= height && width <= height){
            perimRibbon = 2 * (length + width);
        }
        else if(width <= length && height <= length){
            perimRibbon = 2  * (width + height);
        }
        else if(height <= width && length <= width){
            perimRibbon = 2 * (height + length);
        }
        else {
            printf("Error calculating ribbon\n");
        }

        // Calculate ribbon for bow (volume of present)
        volumeBow = length * width * height;

        // Update total ribbon 
        totalRibbon = totalRibbon + (perimRibbon + volumeBow);
    }

    printf("Total wrapping paper required: %d square feet\n", totalPaper);
    printf("Total ribbon required: %d feet\n", totalRibbon);

    // Close file
    fclose(fptr);

    return 0;
}