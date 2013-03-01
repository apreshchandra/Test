
//Function created to store the Preveiw image 
function fnImageStorage()
{		
		var str1 = document.getElementById('imgPreveiw').src;			
		var strImageName;
		var i = str1.lastIndexOf('/',(str1.length)-1);
		strImageName = str1.substring(i+1);
		document.getElementById('hdnImage').value = strImageName;
	//	alert(document.getElementById('hdnImage').value);
	//	return true;
	
}