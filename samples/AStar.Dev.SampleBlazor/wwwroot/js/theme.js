window.theme = {
    getPreference: () => {
        return document.documentElement.classList.contains("dark");
    },
    setPreference: (enabled) => {
        const root = document.documentElement;
        if (enabled) {
            root.classList.add("dark");
            localStorage.setItem("darkmode", "true");
        } else {
            root.classList.remove("dark");
            localStorage.setItem("darkmode", "false");
        }
    }
};
