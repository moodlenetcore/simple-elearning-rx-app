import delay from './delay';

// This file mocks a web API by working with the hard-coded data below.
// It uses setTimeout to simulate the delay of an AJAX call.
// All calls return promises.
const users = [
    {
        id: "12345",
        username: "tan",
        password: "123456"
    }
];

function replaceAll(str, find, replace) {
    return str.replace(new RegExp(find, 'g'), replace);
}

//This would be performed on the server in a real app. Just stubbing in.
const generateId = (user) => {
    return replaceAll(user.title, ' ', '-');
};

class UserApi {
    static getAllUsers() {
        return new Promise((resolve) => {
            setTimeout(() => {
                resolve(Object.assign([], users));
            }, delay);
        });
    }

    static saveUser(user) {
        user = Object.assign({}, user); // to avoid manipulating object passed in.
        return new Promise((resolve, reject) => {
            setTimeout(() => {
                // Simulate server-side validation
                const minUserTitleLength = 1;
                if (user.title.length < minUserTitleLength) {
                    reject(`Title must be at least ${minUserTitleLength} characters.`);
                }

                if (user.id) {
                    const existingUserIndex = users.findIndex(a => a.id === user.id);
                    users.splice(existingUserIndex, 1, user);
                } else {
                    //Just simulating creation here.
                    //The server would generate ids and watchHref's for new users in a real app.
                    //Cloning so copy returned is passed by value rather than by reference.
                    user.id = generateId(user);
                    user.watchHref = `http://www.pluralsight.com/users/${user.id}`;
                    users.push(user);
                }

                resolve(user);
            }, delay);
        });
    }

    static deleteUser(userId) {
        return new Promise((resolve) => {
            setTimeout(() => {
                const indexOfUserToDelete = users.findIndex(user => user.id === userId);
                users.splice(indexOfUserToDelete, 1);
                resolve();
            }, delay);
        });
    }


    static getUser(userId) {
        return new Promise((resolve) => {
            setTimeout(() => {
                const existingUserIndex = users.findIndex(user => user.id === userId);
                
                const userFound = Object.assign({}, users[existingUserIndex]);

                resolve(userFound);

            }, delay);
        });
    }

}

export default UserApi;
