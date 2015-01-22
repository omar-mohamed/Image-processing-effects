function New=SSR(Old,Sigma)
filtered=double(Gauss2DFilter(Old,Sigma));
temp=double(Old+1)./(filtered+1);
retinex=log(temp);
New=Contrast(retinex,0,255);
imshow(New)
end