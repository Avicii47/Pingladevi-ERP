 
        function record() {
            var recognition = new webkitSpeechRecognition();
            recognition.lang = "mr";

            recognition.onresult = function (event) {
                // console.log(event);
                document.getElementById('txtName').value = event.results[0][0].transcript;
            }

            recognition.start();

        }
    
    
        function record1() {
            var recognition = new webkitSpeechRecognition();
            recognition.lang = "eng-gb";

            recognition.onresult = function (event) {
                // console.log(event);
                document.getElementById('txtMobileno').value = event.results[0][0].transcript;
            }

            recognition.start();

        }
    
    
        function record2() {
            var recognition = new webkitSpeechRecognition();
            recognition.lang = "mr";

            recognition.onresult = function (event) {
                // console.log(event);
                document.getElementById('txtPaymentInWord').value = event.results[0][0].transcript;
            }

            recognition.start();

        }
    
        function record3() {
            var recognition = new webkitSpeechRecognition();
            recognition.lang = "mr";

            recognition.onresult = function (event) {
                // console.log(event);
                document.getElementById('txtPaymentInNo').value = event.results[0][0].transcript;
            }

            recognition.start();

        }
function record4() {
    var recognition = new webkitSpeechRecognition();
    recognition.lang = "mr";

    recognition.onresult = function (event) {
        // console.log(event);
        document.getElementById('txtcategory').value = event.results[0][0].transcript;
    }

    recognition.start();

}

function record5() {
    var recognition = new webkitSpeechRecognition();
    recognition.lang = "mr";

    recognition.onresult = function (event) {
        // console.log(event);
        document.getElementById('txtsubcategory').value = event.results[0][0].transcript;
    }

    recognition.start();

}
function record6() {
    var recognition = new webkitSpeechRecognition();
    recognition.lang = "mr";

    recognition.onresult = function (event) {
        // console.log(event);
        document.getElementById('txtunit').value = event.results[0][0].transcript;
    }

    recognition.start();

}
