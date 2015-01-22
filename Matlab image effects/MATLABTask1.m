function MATLABTask1(I)
 
I=imcomplement(I);
[B,L,N,A]=bwboundaries(I);
num=0;
for i=1:N
    num=num+length(B{i})-1;
end
sprintf('sum of pixels in the boundary for shape %d',num)
bound =bwmorph(I,'remove');
subplot(224),imshow(bound),title('boundary')

se = strel('rectangle',[60,60]); 
rectangles=imopen(I,se);
obj1=bwconncomp(rectangles);
subplot(221),imshow(rectangles),title('')
BE=(I-rectangles);
% subplot(222),imshow(BE),title('')
se2=strel('rectangle',[40,40]);
BE=imerode(BE,se2);
subplot(223), imshow(BE), title('erosion')
obj=bwconncomp(BE);
num=obj.NumObjects;
sprintf('number of circles %d',num)

num=num+obj1.NumObjects;
sprintf('number of shapes %d',num)

end