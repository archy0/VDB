let url = "https://localhost:44308/api/Organizacijas/OrgDati?page=";
window.onload = function () {
    var xhttp = new XMLHttpRequest();

    xhttp.onreadystatechange = function () {
        if (this.readyState == 2) {
            this.responseType = "json";
        }

        if (this.readyState == 4 && this.status == 200) {
            let table = document.getElementById("table");
            let results = this.response;
            let rootElement = results.rootElement;
            var items;

            for (var i = 0; i < rootElement.length; i++) {
                items += "<tr><td></td><td></td><td></td></tr>";
            }

        }
    }
}