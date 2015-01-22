function [BlueMMs, Count]= MATLABTask2(InputImage)

red = InputImage(:, :, 1);
green = InputImage(:, :, 2);
blue = InputImage(:, :, 3);
mm = blue - red/2 - green/2 ;
[level] = graythresh(mm);
 n = im2bw(mm,level);
 v = n;
se2=strel('disk',13);
eroded=imerode(v,se2);
obj=bwconncomp(eroded);
Count=obj.NumObjects;
dilated=imdilate(eroded,se2);
dilated=imfill(dilated,'holes');
%imshow(dilated);

out(:,:,1)=uint8(dilated).*uint8(red);
out(:,:,2)=uint8(dilated).*uint8(green);
out(:,:,3)=uint8(dilated).*uint8(blue);
BlueMMs=out;
fprintf('Number of blue m&ms is %d',Count);
return 
end