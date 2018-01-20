### 图元生成系统设计导引文档

计算机图形展示技术，就是利用编程手段和数学方法，在计算机电子屏幕上显示一系列图形的技术。

#### 一、像素

像素，为影像显示的基本单位。单色影像的每个像素有自己的灰阶影像。0通常表示黑，而最大值通常表示白色。例如，在一个8位元影像中，最大的无号整数是255，所以这是白色的值。在彩色影像中，像素可以用它的色调，饱和度，和亮度来表示，但是通常用红绿蓝强度来表示。像素可以是长方形的或者方形的。

![sony-dsc-29-625x1000](.\images\sony-dsc-29-625x1000.jpg)

![Nexus_one_screen_microscope](.\images\Nexus_one_screen_microscope.jpg)

![LCDpixelsRGB](.\images\LCDpixelsRGB.jpg)

![200px-Pixel_geometry_01_Pengo](.\images\200px-Pixel_geometry_01_Pengo.jpg)

![4eaTi](.\images\4eaTi.jpg)

一个像素所能表达的不同颜色数取决于比特每像素（BPP,bit per pixel）。这个最大数可以通过取2的色彩深度次幂来得到。例如，常见的取值有：

- 8 bpp：256色，亦称为“8位元”；
- 16 bpp：216=65,536色，称为高彩色，亦称为“16位元”；
- 24 bpp：224=16,777,216色，称为真彩色，通常的记法为“1670万色”，亦称为“24位色”；
- 32 bpp：224 +28，电脑领域较常见的32位色并不是表示232种颜色，而是在24位色基础上增加了8位元（28=256级）的灰阶，因此32位元的色彩总数和24位元是相同的，32位元也称为全彩。
- 48 bpp：248=281,474,976,710,656色，用于很多专业的扫描器。




#### 二、分辨率

| 电脑标准                                     | 分辨率       | 比例              |
| ---------------------------------------- | --------- | --------------- |
| [CGA](https://zh.wikipedia.org/wiki/%E5%BD%A9%E8%89%B2%E5%9B%BE%E5%BD%A2%E9%80%82%E9%85%8D%E5%99%A8) | 320×200   | 16:10           |
| [QVGA](https://zh.wikipedia.org/wiki/QVGA) | 320×240   | 4:3             |
| [WQVGA](https://zh.wikipedia.org/w/index.php?title=WQVGA&action=edit&redlink=1) | 480×272   | 16:9            |
| [B&W Macintosh/Macintosh LC](https://zh.wikipedia.org/wiki/Mac%E9%9B%BB%E8%85%A6) | 512×384   | 4:3             |
| [HVGA](https://zh.wikipedia.org/wiki/%E8%A7%86%E9%A2%91%E5%9B%BE%E5%BD%A2%E9%98%B5%E5%88%97) | 480×320   | 3:2             |
| [EGA](https://zh.wikipedia.org/w/index.php?title=Enhanced_Graphics_Adapter&action=edit&redlink=1) | 640×350   | 约5:3            |
| [nHD](https://zh.wikipedia.org/w/index.php?title=NHD&action=edit&redlink=1) | 640×360   | 16:9            |
| [VGA](https://zh.wikipedia.org/wiki/VGA) 及 [MCGA](https://zh.wikipedia.org/wiki/%E5%A4%9A%E8%89%B2%E5%9B%BE%E5%BD%A2%E9%80%82%E9%85%8D%E5%99%A8) | 640×480   | 4:3             |
| [HGC](https://zh.wikipedia.org/wiki/%E5%92%8C%E8%A8%98%E7%92%B0%E7%90%83%E9%9B%BB%E8%A8%8A) | 720×348   | 60:29           |
| [MDA](https://zh.wikipedia.org/wiki/%E5%8D%95%E8%89%B2%E6%98%BE%E7%A4%BA%E9%80%82%E9%85%8D%E5%99%A8) | 720×350   | 72:35           |
| [Apple Lisa](https://zh.wikipedia.org/wiki/Apple_Lisa) | 720×360   | 2:1             |
| [SVGA](https://zh.wikipedia.org/wiki/SVGA) | 800×600   | 4:3             |
| [WVGA](https://zh.wikipedia.org/wiki/WVGA) | 800×480   | 5:3             |
| [FWVGA](https://zh.wikipedia.org/wiki/FWVGA) | 854×480   | 约16:9           |
| [qHD](https://zh.wikipedia.org/wiki/QHD) | 960×540   | 16:9            |
| [DVGA](https://zh.wikipedia.org/w/index.php?title=DVGA&action=edit&redlink=1) | 960×640   | 3:2             |
| [WSVGA](https://zh.wikipedia.org/w/index.php?title=WSVGA&action=edit&redlink=1) | 1024×600  | 128:75          |
| [XGA](https://zh.wikipedia.org/wiki/XGA) | 1024×768  | 4:3             |
| [XGA+](https://zh.wikipedia.org/w/index.php?title=XGA%2B&action=edit&redlink=1) | 1152×864  | 4:3             |
| [HD](https://zh.wikipedia.org/wiki/HD)   | 1280×720  | 16:9            |
| [WXGA](https://zh.wikipedia.org/wiki/WXGA) | 1280×768  | 15:9            |
| [WXGA](https://zh.wikipedia.org/wiki/WXGA) | 1280×800  | 16:10           |
| [SXGA](https://zh.wikipedia.org/wiki/SXGA) | 1280×1024 | 5:4             |
| [WXSGA+](https://zh.wikipedia.org/w/index.php?title=WXSGA%2B&action=edit&redlink=1) | 1366×768  | 683:384和16:9    |
| [WXGA+](https://zh.wikipedia.org/w/index.php?title=WXGA%2B&action=edit&redlink=1) | 1440×900  | 16:10           |
| [SXGA+](https://zh.wikipedia.org/wiki/SXGA%2B) | 1400×1050 | 4:3             |
| [WSXGA](https://zh.wikipedia.org/w/index.php?title=WSXGA&action=edit&redlink=1) | 1600×1024 | 25:16           |
| [WSXGA+](https://zh.wikipedia.org/w/index.php?title=WSXGA%2B&action=edit&redlink=1) | 1680×1050 | 16:10           |
| [UXGA](https://zh.wikipedia.org/wiki/UXGA) | 1600×1200 | 4:3             |
| [WUXGA](https://zh.wikipedia.org/wiki/WUXGA) | 1920×1200 | 16:10           |
| [Full HD](https://zh.wikipedia.org/wiki/Full_HD) | 1920×1080 | 16:9            |
| [2K Resolution](https://zh.wikipedia.org/wiki/2K%E8%A7%A3%E6%9E%90%E5%BA%A6) | 2048×1080 | 约17:9           |
| [QXGA](https://zh.wikipedia.org/wiki/QXGA) | 2048×1536 | 4:3             |
| [QHD](https://zh.wikipedia.org/wiki/QHD) | 2560×1080 | 21:9            |
| [WQHD](https://zh.wikipedia.org/w/index.php?title=WQHD&action=edit&redlink=1) | 2560×1440 | 16:9            |
| [WQXGA](https://zh.wikipedia.org/w/index.php?title=WQXGA&action=edit&redlink=1) | 2560×1600 | 16:10           |
| [QSXGA](https://zh.wikipedia.org/w/index.php?title=QSXGA&action=edit&redlink=1) | 2560×2048 | 5:4             |
| [WQSXGA](https://zh.wikipedia.org/w/index.php?title=WQSXGA&action=edit&redlink=1) | 3200×2048 | 约15.6:10        |
| [QUXGA](https://zh.wikipedia.org/w/index.php?title=QUXGA&action=edit&redlink=1) | 3200×2400 | 4:3             |
| Ultra-Wide QHD                           | 3440×1440 | 21:9            |
| [QFHD](https://zh.wikipedia.org/w/index.php?title=QFHD&action=edit&redlink=1) | 3840×2160 | 16:9            |
| [4K Ultra HD](https://zh.wikipedia.org/wiki/4K%E8%A7%A3%E6%9E%90%E5%BA%A6) | 4096×2160 | (256:135和约17:9) |
| [WQUXGA](https://zh.wikipedia.org/w/index.php?title=WQUXGA&action=edit&redlink=1) | 3840×2400 | 16:10           |
| [HSXGA](https://zh.wikipedia.org/w/index.php?title=HSXGA&action=edit&redlink=1) | 5120×4096 | 5:4             |
| [WHSXGA](https://zh.wikipedia.org/w/index.php?title=WHSXGA&action=edit&redlink=1) | 6400×4096 | 25:16           |
| [HUXGA](https://zh.wikipedia.org/w/index.php?title=HUXGA&action=edit&redlink=1) | 6400×4800 | 4:3             |
| [8K Ultra HD](https://zh.wikipedia.org/wiki/%E8%B6%85%E9%AB%98%E7%95%AB%E8%B3%AA%E9%9B%BB%E8%A6%96) | 7680×4320 | 16:9            |
| [WHUXGA](https://zh.wikipedia.org/w/index.php?title=WHUXGA&action=edit&redlink=1) | 7680×4800 | 16:10           |
| 模拟电视标准                                   | 分辨率       |                 |
| [PAL](https://zh.wikipedia.org/wiki/PAL%E5%88%B6%E5%BC%8F) | 720×576   | 5:4，非正方形的像素     |
| PAL VHS                                  | 320×576   |                 |
| [NTSC](https://zh.wikipedia.org/wiki/NTSC) | 720×480   |                 |
| NTSC VHS                                 | 320×482   | 3:2，非正方形的像素     |
| 数位电视标准                                   | 分辨率       |                 |
| NTSC（首选格式）                               | 648×486   | 4:3             |
| D-1 NTSC                                 | 720×486   |                 |
| D-1 NTSC (square pixels)                 | 720×540   |                 |
| PAL                                      | 720×486   |                 |
| D-1 PAL                                  | 720×576   | 4:3             |
| D-1 PAL（正方形像素）                           | 768×576   |                 |
| [HDTV](https://zh.wikipedia.org/wiki/HDTV) 1080i | 1920×1080 | 16:9            |
| [HDMI](https://zh.wikipedia.org/wiki/HDMI) | 1366×768  | 16:9            |
| [HDTV](https://zh.wikipedia.org/wiki/HDTV) 720p | 1280×720  | 16:9            |
| [EDTV](https://zh.wikipedia.org/w/index.php?title=EDTV&action=edit&redlink=1) 480p | 704×480   |                 |
| 数位电影标准                                   | 分辨率       |                 |
| 协会标准(2k)                                 | 2048×1536 | 4:3             |
| 协会标准(4k)                                 | 4096×3072 | 4:3             |
| [DVD](https://zh.wikipedia.org/wiki/DVD) "NTSC" | 720×480   | 3:2，非正方形的像素     |
| DVD "PAL"                                | 720×576   | 5:4，非正方形的像素     |
| [VCD](https://zh.wikipedia.org/wiki/VCD) "NTSC" | 352×240   | 22:15，非正方形的像素   |
| [VCD](https://zh.wikipedia.org/wiki/VCD) "PAL" | 352×288   | 11:9，非正方形的像素    |
| [LD](https://zh.wikipedia.org/wiki/LD)   | 560×360   |                 |

实际的电子屏幕纵横像素数一般不相等，但为了便于演示基本的图形学算法原理，图元生成系统将用N阶网格代表整个显示屏幕；其中一个单元格代表一个像素。该系统只用于演示基本图元的生成、图元属性的设置，二维几何变换；不涉及子像素绘制、三维图像生成及其属性设置、三维变换，光照效果及其它等较为复杂的内容。

