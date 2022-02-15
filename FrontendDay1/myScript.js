//probao sakriti odredjeni paragraph klikom na odredjeni gumb nisam uspio 

function visibility(clicked_id) {
    var x = document.getElementById(clicked_id)
    if (x.style.display === "none") {
      x.style.display = "block";
    } else {
      x.style.display = "none";
    }
}