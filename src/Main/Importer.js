export function counter () {
    return import("./Counter.fs").then(module => { return module.default});
}
