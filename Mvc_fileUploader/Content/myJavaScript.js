		window.addEventListener('load', sMessage);		
		
		function sMessage()
		{
			var x = document.getElementById("sM");
			x.innerHTML = "File upload successful !";
			setTimeout('revertSuccessMessage()', 5000);
		}

		function revertSuccessMessage()
		{
			var x = document.getElementById("sM");
			x.innerHTML = "Choose a file to upload !";
		}

