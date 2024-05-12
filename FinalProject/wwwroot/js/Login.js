

const uri = '/Login'; 
document.getElementById('login-form').addEventListener('submit', function (event) {
    event.preventDefault();
    LoginUser();
});

function LoginUser() {
    const EnterName = document.getElementById('enter-name').value;
    const EnterPassword = document.getElementById('enter-password').value;

    const item = {
        Name: EnterName,
        Password: EnterPassword
    };

    fetch(uri, {
        
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
        
    })
    .then(response => {
        
        if (!response.ok) {
            throw new Error('Failed to login');
        }
        return response.text();
    })
    .then(data => {
        console.log("kkkkkkk");
        saveToken(data);
        })
    .catch(error => {
        console.error('Error:', error);
    });
}
function saveToken(token) {
    console.log("wwwwwwwww");
    localStorage.setItem("token", token);
    var homePagePath = "Taskk.html";
    window.location.href = homePagePath;
}