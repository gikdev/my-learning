mod shapes;

use crate::shapes::{
    rect::Rect
};

fn main() {
    let rectangle = Rect::default();

    for point in &rectangle {}
}
