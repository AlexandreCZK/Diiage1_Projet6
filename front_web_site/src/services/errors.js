export default new class ErrorHandling {
    alertError(err) {
        let error = "";
        if (err.response != undefined) {
            if (err.response.status != null && err.response.status != "") {
                error = error + "Status: " + err.response.status + ". ";
            }
            if (err.response.data != null) {
                if (err.response.data.message != "" && err.response.data.message != undefined) {
                    error = error + err.response.data.message + ".";
                } else {
                    error = error + "An error occured."
                }
            }
        }
        else{
            error = "An error occured"; 
        }
        console.log(err);
        this.displayError(error);
    }

    alertCustomError(status, message) {
        let error = "";
        error = error + "Status: " + status + ". ";
        error = error + message + ".";
        this.displayError(error);
    }

    displayError(error){
        document.getElementById("error").innerHTML = error;
    }
}