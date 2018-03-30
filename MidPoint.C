/*运行在Turbo C环境下*/
#include "stdio.h"
#include "graphics.h"
void setPixel(int x,int y);
void circlePlotPoints(int xc,int yc,int x,int y);
void circleMidpoint(int xc,int yc,int r);
int main()
{
	int gdriver = DETECT, gmode, errorcode;
	initgraph(&gdriver, &gmode, "");
	errorcode = graphresult();
	if (errorcode != grOk)
	{
		printf("Graphics error: %s\n", grapherrormsg(errorcode));
		printf("Press any key to halt:");
		getch();
		exit(1);
	}
	circleMidpoint(getmaxx()/2,getmaxy()/2,getmaxy()/2-50);
	getch();
	closegraph();
	return 0;
}
void setPixel(int x,int y)
{
    putpixel(x,y,GREEN);
}
void circlePlotPoints(int xc,int yc,int x,int y)
{
    setPixel(xc+x,yc+y);
    setPixel(xc-x,yc+y);
    setPixel(xc+x,yc-y);
    setPixel(xc-x,yc-y);
    setPixel(xc+y,yc+x);
    setPixel(xc-y,yc+x);
    setPixel(xc+y,yc-x);
    setPixel(xc-y,yc-x);
}
void circleMidpoint(int xc,int yc,int r)
{
    int x=0;
    int y=r;
    int d=1-r;
    circlePlotPoints(xc,yc,x,y);
    while(x<y)
    {
        x++;
        if(d<0)
        {
            d+=2*x+1;
        }
        else
        {
            y--;
            d+=2*(x-y)+1;
        }
        circlePlotPoints(xc,yc,x,y);
    }
}

