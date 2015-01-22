function[New] =LocalHE(Old,WinSize)
A=Old;
New=A;
     
N=WinSize;
M=WinSize;


mid_val=round((N*M)/2);

num=0;
for i=1:N
    for j=1:M
        num=num+1;
        if(num==mid_val)
            zeroN=i-1;
            zeroM=j-1;
            break;
        end
    end
end
B=padarray(A,[zeroN,zeroM]);

for i= 1:size(B,1)-((zeroN*2)+1)
    
    for j=1:size(B,2)-((zeroM*2)+1)
        cdf=zeros(256,1);
        inc=1;
        for x=1:N
            for y=1:M
                %find the middle element
                if(inc==mid_val)
                    element=B(i+x-1,j+y-1)+1;
                end
                pos=B(i+x-1,j+y-1)+1;
                cdf(pos)=cdf(pos)+1;
                inc=inc+1;
            end
        end
        
        %compute the cummulative density for window  
        
        for l=2:256
            cdf(l)=cdf(l)+cdf(l-1);
        end
            New(i,j)=round(cdf(element)/(M*N)*255);
     end
end
return
end