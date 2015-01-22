function New = Gauss2DFilter(Old, Sigma)
MskSize = 2 * int32(3.7 * Sigma - 0.5) + 1;
GF2D = fspecial('gaussian', [double(MskSize) double(MskSize)], Sigma) ;
New = imfilter(Old, GF2D) ;
