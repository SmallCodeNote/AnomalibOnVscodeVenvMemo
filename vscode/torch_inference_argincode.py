import logging
from argparse import ArgumentParser, Namespace
from pathlib import Path

import torch

from anomalib.data.utils import generate_output_image_filename, get_image_filenames, read_image
from anomalib.data.utils.image import save_image, show_image
from anomalib.deploy import TorchInferencer
from anomalib.utils.visualization import ImageVisualizer

logger = logging.getLogger(__name__)

def infer(args: Namespace) -> None:
    torch.set_grad_enabled(mode=False)

    # Create the inferencer and visualizer.
    inferencer = TorchInferencer(path=args.weights, device=args.device)
    visualizer = ImageVisualizer(mode=args.visualization_mode, task=args.task)

    filenames = get_image_filenames(path=args.input)
    for filename in filenames:
        image = read_image(filename, as_tensor=True)
        predictions = inferencer.predict(image=image)
        output = visualizer.visualize_image(predictions)

        if args.output is None and args.show is False:
            msg = "Neither output path is provided nor show flag is set. Inferencer will run but return nothing."
            logger.warning(msg)

        if args.output:
            file_path = generate_output_image_filename(input_path=filename, output_path=args.output)
            save_image(filename=file_path, image=output)

        # Show the image in case the flag is set by the user.
        if args.show:
            show_image(title="Output Image", image=output)


if __name__ == "__main__":
    args = Namespace(
        weights=Path(R"R:\model\weights\torch\model.pt"), 
        input=Path(R"R:\train\ng\0000.jpg"), 
        output=Path(R"R:\result\0000.jpg"),
        device='auto',  #["auto", "cpu", "gpu", "cuda"]
        task='segmentation',  #["classification", "detection", "segmentation"]
        visualization_mode='full', #["full", "simple"]
        show=True 
    )
    infer(args=args)